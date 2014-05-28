using System;
using System.Collections.Generic;
using System.Linq;
using D3apiData.API.Collectors;
using D3apiData.API.Objects;
using D3apiData.API.Objects.Artisan;
using D3apiData.API.Objects.Follower;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Images;
using D3apiData.API.Objects.Item;
using D3apiData.API.Objects.Profile;
using D3apiData.API.UrlConstruction;
using D3apiData.JSON;

namespace D3apiData.API
{
    /// <summary>
    /// provides data connection between .net classes and online api
    /// </summary>
    public class D3Data
    {
        private readonly Locales _locale;
        private ID3Collector _collector;
        private readonly List<IUrlConstructionProvider> _urlConstructors;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="collector"></param>
        /// <param name="urlConstructors"></param>
        public D3Data(Locales locale, ID3Collector collector, List<IUrlConstructionProvider> urlConstructors)
        {
            if (collector == null) throw new ArgumentNullException("collector");
            if (urlConstructors == null) throw new ArgumentNullException("urlConstructors");
            _locale = locale;
            _collector = collector;
            _urlConstructors = urlConstructors;
        }


        /// <summary>
        /// data collector for d3 api
        /// </summary>
        public ID3Collector Collector
        {
            get { return _collector; }
            set
            {
                if(value != null)
                    _collector = value;
            }
        }


        /// <summary>
        /// gets object from api by type and id
        /// </summary>
        /// <typeparam name="T">type of returning object</typeparam>
        /// <param name="id">identifier of object</param>
        /// <returns>object from api</returns>
        public T GetApiType<T>(ApiId id) where T : class, IBaseObject
        {
            var urlconstructor = _urlConstructors.First(c => c.ApiType == typeof (T));
            using (var stream = Collector.CollectStreamFromUrl(urlconstructor.ConstructUrlFromId(id,_locale)))
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
            using (var stream = Collector.CollectStreamFromUrl(url))
                return JsonUtility.ObjectFromJsonStream<T>(stream);
        }

        /// <summary>
        /// gets Profile object from api by battletag
        /// </summary>
        /// <param name="battletag"></param>
        /// <returns></returns>
        public Profile GetProfileByBattletag(string battletag)
        {
            return GetApiType<Profile>(new ApiId(battletag));
        }

        /// <summary>
        /// gets Hero object from api by battletag and heroid
        /// </summary>
        /// <param name="battletag"></param>
        /// <param name="heroid"></param>
        /// <returns></returns>
        public Hero GetHeroById(string battletag, string heroid)
        {
            return GetApiType<Hero>(new ApiId(battletag, heroid));
        }

        /// <summary>
        /// gets Item object from api by id
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public Item GetItemById(string itemid)
        {
            return GetApiType<Item>(new ApiId(itemid));
        }

        /// <summary>
        /// gets Artisan object from api by artisan's name
        /// </summary>
        /// <param name="artisan"></param>
        /// <returns></returns>
        public Artisan GetArtisanByName(string artisan)
        {
            return GetApiType<Artisan>(new ApiId(artisan));
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
            return GetApiType<Follower>(new ApiId(follower));
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
            var urlconstructor = _urlConstructors.First(c => c.ApiType == typeof(D3Icon));
            var apiid = new ApiId("skills/" + (int) size + "/", iconid);
            using (var stream = Collector.CollectStreamFromUrl(urlconstructor.ConstructUrlFromId(apiid, _locale)))
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
            var urlconstructor = _urlConstructors.First(c => c.ApiType == typeof(D3Icon));
            var apiid = new ApiId("items/" + size.ToString().ToLower() + "/", iconid);
            var url = urlconstructor.ConstructUrlFromId(apiid,_locale);
            using (var stream = Collector.CollectStreamFromUrl(url))
                return new D3Icon(stream);
        }

        /// <summary>
        /// gets Item object from api by tooltip params
        /// </summary>
        /// <param name="tooltip"></param>
        /// <returns></returns>
        public Item GetItemByTooltipParams(string tooltip)
        {
            return GetItemById(tooltip.Split(new[] {"/"}, StringSplitOptions.None)[1]);
        }
    }
}
