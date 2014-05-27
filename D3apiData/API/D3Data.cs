using System;
using System.Collections.Generic;
using D3apiData.API.Objects;
using D3apiData.API.Objects.Artisan;
using D3apiData.API.Objects.Follower;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Images;
using D3apiData.API.Objects.Item;
using D3apiData.API.Objects.Profile;
using D3apiData.JSON;
using D3apiData.WebClient;

namespace D3apiData.API
{
    /// <summary>
    /// provides data connection between .net classes and online api
    /// </summary>
    public class D3Data
    {
        private readonly Dictionary<Locales, string> _hostLookup = new Dictionary<Locales, string>
        {
            { Locales.en_US, "us" },
            { Locales.en_GB, "eu" },
            { Locales.es_MX, "us" },
            { Locales.es_ES, "eu" },
            { Locales.it_IT, "eu" },
            { Locales.pt_PT, "eu" },
            { Locales.pt_BR, "us" },
            { Locales.fr_FR, "eu" },
            { Locales.ru_RU, "eu" },
            { Locales.pl_PL, "eu" },
            { Locales.de_DE, "eu" },
            { Locales.ko_KR, "kr" },
            { Locales.zh_TW, "tw" }
        };

        private readonly Dictionary<ApiTypes, Func<string, string>> _urlLookup = new Dictionary<ApiTypes, Func<string, string>>();

        private const string Mediahost = ".media.blizzard.com/d3/";
        private const string Apihost = ".battle.net";
        private const string Apipath = "/api/d3/";

        private string _battletag = "";
        private readonly ID3Collector _collector;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="properties">must hold correct CollectMode</param>
        public D3Data(Properties properties)
        {
            var mode = properties.CollectMode;
            _urlLookup[ApiTypes.Profile] =
                btag =>
                    _hostLookup[properties.Locale] + Apihost + Apipath + "profile/" +
                    Uri.EscapeUriString(FormatBattletag(btag) + "/");
            _urlLookup[ApiTypes.Hero] =
                hero =>
                    _hostLookup[properties.Locale] + Apihost + Apipath + "profile/" +
                    Uri.EscapeUriString(FormatBattletag(Battletag) + "/hero/" + hero);
            _urlLookup[ApiTypes.Item] =
                item => _hostLookup[properties.Locale] + Apihost + Apipath + "data/item/" + Uri.EscapeUriString(item);
            _urlLookup[ApiTypes.Follower] =
                follower => _hostLookup[properties.Locale] + Apihost + Apipath + "data/follower/" + Uri.EscapeUriString(follower);
            _urlLookup[ApiTypes.Artisan] =
                artisan =>
                    _hostLookup[properties.Locale] + Apihost + Apipath + "data/artisan/" + Uri.EscapeUriString(artisan);
            _urlLookup[ApiTypes.IconItem] =
                itemIcon => _hostLookup[properties.Locale] + Mediahost + "icons/items/" + Uri.EscapeUriString(itemIcon) + ".png";
            _urlLookup[ApiTypes.IconSkill] =
                skillIcon => _hostLookup[properties.Locale] + Mediahost + "icons/skills/" + Uri.EscapeUriString(skillIcon) + ".png";

            switch (mode)
            {
                case CollectMode.Online:
                    _collector = new OnlineCollector(new D3WebClient());
                    break;
                case CollectMode.Offline:
                    _collector = new CacheCollector(properties.CachePath);
                    break;
                case CollectMode.TryCacheThenOnline:
                    _collector = new TryCacheThenOnlineCollector(new CacheCollector(properties.CachePath), new OnlineCollector(new D3WebClient()));
                    break;
                case CollectMode.OnlineWithCache:
                    _collector = new OnlineWithCacheCollector(new CacheCollector(properties.CachePath), new OnlineCollector(new D3WebClient()));
                    break;
            }
        }

        /// <summary>
        /// battletag of user
        /// </summary>
        public string Battletag
        {
            get { return _battletag; }
            set { _battletag = value; }
        }

        /// <summary>
        /// format battletag to match url format
        /// </summary>
        /// <param name="battletag"></param>
        /// <returns></returns>
        private string FormatBattletag(string battletag)
        {
            Battletag = battletag;
            return battletag.Replace("#", "-");
        }


        /// <summary>
        /// gets object from api by type and id
        /// </summary>
        /// <typeparam name="T">type of returning object</typeparam>
        /// <param name="type">apitype</param>
        /// <param name="id">identifier of object</param>
        /// <returns>object from api</returns>
        public T GetApiType<T>(ApiTypes type, string id) where T : class, IBaseObject
        {
            using (var stream = _collector.CollectStreamFromUrl(_urlLookup[type](id)))
                return JsonUtility.ObjectFromJsonStream<T>(stream);
        }

        /// <summary>
        /// gets object from api by url (REST principle)
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="url">REST url eg eu.battle.net/api/d3/data/item/itemid </param>
        /// <returns>object from api</returns>
        public T GetApiType<T>(string url) where T : class, IBaseObject
        {
            using (var stream = _collector.CollectStreamFromUrl(url))
                return JsonUtility.ObjectFromJsonStream<T>(stream);
        }

        /// <summary>
        /// gets Profile object from api by battletag
        /// </summary>
        /// <param name="battletag"></param>
        /// <returns></returns>
        public Profile GetProfileByBattletag(string battletag)
        {
            return GetApiType<Profile>(ApiTypes.Profile, battletag);
        }

        /// <summary>
        /// gets Hero object from api by id; battletag must be set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hero GetHeroById(string id)
        {
            if (Battletag != "")
                return GetApiType<Hero>(ApiTypes.Hero, id);
            throw new ArgumentException("battletag");
        }

        /// <summary>
        /// gets Item object from api by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Item GetItemById(string id)
        {
            return GetApiType<Item>(ApiTypes.Item, id);
        }

        /// <summary>
        /// gets Artisan object from api by artisan's name
        /// </summary>
        /// <param name="artisan"></param>
        /// <returns></returns>
        public Artisan GetArtisanByName(string artisan)
        {
            return GetApiType<Artisan>(ApiTypes.Artisan, artisan);
        }

        /// <summary>
        /// gets Artisan object from api by artisan enum
        /// </summary>
        /// <param name="artisan"></param>
        /// <returns></returns>
        public Artisan GetArtisanByName(Artisans artisan)
        {
            return GetArtisanByName(artisan.ToString().ToLower());
        }

        /// <summary>
        /// gets Follower object from api by follower's name
        /// </summary>
        /// <param name="follower"></param>
        /// <returns></returns>
        public Follower GetFollowerByName(string follower)
        {
            return GetApiType<Follower>(ApiTypes.Follower, follower);
        }

        /// <summary>
        /// gets Follower object from api by follower enum
        /// </summary>
        /// <param name="follower"></param>
        /// <returns></returns>
        public Follower GetFollowerByName(Followers follower)
        {
            return GetFollowerByName(follower.ToString().ToLower());
        }

        /// <summary>
        /// gets D3Icon from media api by skill icon id
        /// </summary>
        /// <param name="iconid"></param>
        /// <param name="size">size of icon</param>
        /// <returns></returns>
        public D3Icon GetSkillIconById(string iconid, SkillIconSizes size = SkillIconSizes.Medium)
        {
            using (var stream = _collector.CollectStreamFromUrl(_urlLookup[ApiTypes.IconSkill]((int)size + "/" + iconid)))
                return new D3Icon(stream);
        }

        /// <summary>
        /// gets D3Icon from media api by item icon id
        /// </summary>
        /// <param name="iconid"></param>
        /// <param name="size">size of icon</param>
        /// <returns></returns>
        public D3Icon GetItemIconById(string iconid, ItemIconSizes size = ItemIconSizes.Large)
        {
            using (var stream = _collector.CollectStreamFromUrl(_urlLookup[ApiTypes.IconItem](size.ToString().ToLower() + "/" + iconid)))
                return new D3Icon(stream);
        }
    }
}
