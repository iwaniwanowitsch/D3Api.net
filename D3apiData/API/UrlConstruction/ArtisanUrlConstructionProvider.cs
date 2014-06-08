using System;
using D3apiData.API.Objects.Artisan;

namespace D3apiData.API.UrlConstruction
{
    /// <summary>
    /// artisan url construction
    /// </summary>
    public class ArtisanUrlConstructionProvider : BasicUrlConstructionProvider, IUrlConstructionProvider
    {

        /// <summary />
        public Type ApiType { get; private set; }

        /// <summary />
        public ArtisanUrlConstructionProvider(Locales locale) : base(locale)
        {
            ApiType = typeof (Artisan);
        }

        /// <summary />
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public string ConstructUrlFromId(ApiId id)
        {
            return base.HostLookup[Locale] + Apihost + Apipath + "data/artisan/" + Uri.EscapeUriString(id.Id);
        }
    }
}