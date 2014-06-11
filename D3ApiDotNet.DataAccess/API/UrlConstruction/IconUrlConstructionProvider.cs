using System;

namespace D3ApiDotNet.DataAccess.API.UrlConstruction
{
    /// <summary>
    /// icon url construction
    /// </summary>
    public class IconUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {
        /// <summary />
        public IconUrlConstructionProvider(Locales locale) : base(locale)
        {
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id)
        {
            return base.HostLookup[Locale] + Mediahost + "icons/" + Uri.EscapeUriString(id.Id) + Uri.EscapeUriString(id.Id2) + ".png";
        }
    }
}