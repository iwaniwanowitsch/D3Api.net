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
        public ProfileUrlConstructionProvider(Locales locale) : base(locale)
        {
            ApiType = typeof (Profile);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id)
        {
            return base.HostLookup[Locale] + Apihost + Apipath + "profile/" + Uri.EscapeUriString(id.GetFormattedBattletag()) + "/";
        }
    }
}