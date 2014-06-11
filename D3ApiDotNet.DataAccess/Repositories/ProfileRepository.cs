using System;
using System.IO;
using D3ApiDotNet.Core.Objects.Profile;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.UrlConstruction;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class ProfileRepository : JsonObjectRepositoryDecorator<Profile>
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public ProfileRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
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