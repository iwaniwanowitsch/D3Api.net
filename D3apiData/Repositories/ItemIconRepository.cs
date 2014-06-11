using System;
using System.IO;
using D3apiData.API;
using D3apiData.API.Objects.Images;
using D3apiData.API.UrlConstruction;

namespace D3apiData.Repositories
{
    public class ItemIconRepository : IconRepositoryDecorator
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public ItemIconRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public D3Icon GetByIdAndSize(string iconid, ItemIconSizes size = ItemIconSizes.Large)
        {
            var apiid = new ApiId("items/" + size.ToString().ToLower() + "/", iconid);
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(apiid));
        }
    }
}