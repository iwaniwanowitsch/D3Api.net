using System;
using System.IO;
using D3apiData.API;
using D3apiData.API.Objects.Follower;
using D3apiData.API.UrlConstruction;

namespace D3apiData.Repositories
{
    public class FollowerRepository : JsonObjectRepositoryDecorator<Follower>
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public FollowerRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public Follower GetByName(string follower)
        {
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(new ApiId(follower)));
        }
    }
}