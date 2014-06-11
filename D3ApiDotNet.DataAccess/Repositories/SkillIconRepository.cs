using System;
using System.IO;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.UrlConstruction;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class SkillIconRepository : IconRepositoryDecorator
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public SkillIconRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public D3Icon GetByIdAndSize(string iconid, SkillIconSizes size = SkillIconSizes.Medium)
        {
            var apiid = new ApiId("skills/" + (int)size + "/", iconid);
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(apiid));
        }
    }
}