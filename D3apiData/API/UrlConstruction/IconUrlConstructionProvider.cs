﻿using System;
using D3apiData.API.Objects.Images;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// icon url construction
    /// </summary>
    public class IconUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public Type ApiType { get; private set; }

        /// <summary />
        public IconUrlConstructionProvider()
        {
            ApiType = typeof (D3Icon);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id, Locales locale)
        {
            return base.HostLookup[locale] + Mediahost + "icons/" + Uri.EscapeUriString(id.Id) + Uri.EscapeUriString(id.Id2) + ".png";
        }
    }
}