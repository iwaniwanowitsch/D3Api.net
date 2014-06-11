using System;
using System.IO;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.UrlConstruction;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class HeroRepository : JsonObjectRepositoryDecorator<Hero>
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public HeroRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public Hero GetByBattletagAndId(string battletag, string heroid)
        {
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(new ApiId(battletag, heroid)));
        }
    }
}