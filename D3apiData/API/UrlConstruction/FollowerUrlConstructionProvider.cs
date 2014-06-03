using System;
using D3apiData.API.Objects.Follower;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// follower url construction
    /// </summary>
    public class FollowerUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {
        /// <summary />
        public Type ApiType { get; private set; }

        /// <summary />
        public FollowerUrlConstructionProvider()
        {
            ApiType = typeof (Follower);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id, Locales locale)
        {
            return base.HostLookup[locale] + Apihost + Apipath + "data/follower/" + Uri.EscapeUriString(id.Id);
        }
    }
}