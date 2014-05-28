using System;
using D3apiData.API.Objects.Hero;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// hero url construction
    /// </summary>
    public class HeroUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {
        /// <summary />
        public Type ApiType { get; private set; }

        /// <summary />
        public HeroUrlConstructionProvider()
        {
            ApiType = typeof (Hero);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id, Locales locale)
        {
            return base.HostLookup[locale] + Apihost + Apipath + "profile/" + Uri.EscapeUriString(id.GetFormattedBattletag() + "/hero/" + id.Id2);
        }
    }
}