using System;
using System.IO;
using D3apiData.API;
using D3apiData.API.Objects.Artisan;
using D3apiData.API.UrlConstruction;

namespace D3apiData.Repositories
{
    public class ArtisanRepository : JsonObjectRepositoryDecorator<Artisan>
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public ArtisanRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor) : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public Artisan GetByName(string artisan)
        {
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(new ApiId(artisan)));
        }
    }
}