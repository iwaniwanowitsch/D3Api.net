using System;
using System.IO;
using D3apiData.API;
using D3apiData.API.Objects.Profile;
using D3apiData.API.UrlConstruction;

namespace D3apiData.Repositories
{
    public class ProfileRepository : JsonObjectRepositoryDecorator<Profile>
    {
        private readonly ProfileUrlConstructionProvider _urlConstructor;

        public ProfileRepository(IReadonlyRepository<Stream, string> readRepo, ProfileUrlConstructionProvider urlConstructor) : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public Profile GetByBattletag(string battletag)
        {
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(new ApiId(battletag)));
        }
    }
}