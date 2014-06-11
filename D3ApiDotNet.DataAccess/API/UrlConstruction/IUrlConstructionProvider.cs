using System;

namespace D3ApiDotNet.DataAccess.API.UrlConstruction
{
    /// <summary>
    ///  provides construction for url from ids
    /// </summary>
    public interface IUrlConstructionProvider
    {
        Locales Locale { get; set; }
        
        /// <summary>
        /// construction of url from id and locale
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        string ConstructUrlFromId(ApiId id);
    }
}