using System;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    ///  provides construction for url from ids
    /// </summary>
    public interface IUrlConstructionProvider
    {
        /// <summary>
        /// type to check against
        /// </summary>
        Type ApiType { get; }
        
        /// <summary>
        /// construction of url from id and locale
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        string ConstructUrlFromId(ApiId id, Locales locale);
    }
}