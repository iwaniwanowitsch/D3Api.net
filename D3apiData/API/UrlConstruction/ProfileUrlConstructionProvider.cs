using System;
using D3apiData.API.Objects.Profile;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// profile url construction
    /// </summary>
    public class ProfileUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {
        /// <summary />
        public Type ApiType { get; private set; }

        /// <summary />
        public ProfileUrlConstructionProvider()
        {
            ApiType = typeof (Profile);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id, Locales locale)
        {
            return base.HostLookup[locale] + Apihost + Apipath + "profile/" + Uri.EscapeUriString(id.GetFormattedBattletag()) + "/";
        }
    }
}