using System.Drawing;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.API.UrlConstruction;
using System;
using System.IO;

namespace D3ApiDotNet.DataAccess.Repositories
{
    public class ItemRepository : JsonObjectRepositoryDecorator<Item>
    {
        private readonly IUrlConstructionProvider _urlConstructor;

        public ItemRepository(IReadonlyRepository<Stream, string> readRepo, IUrlConstructionProvider urlConstructor)
            : base(readRepo)
        {
            if (urlConstructor == null) throw new ArgumentNullException("urlConstructor");
            _urlConstructor = urlConstructor;
        }

        public Item GetByItemId(string id)
        {
            return base.Retrieve(_urlConstructor.ConstructUrlFromId(new ApiId(id)));
        }

        public Item GetByTooltipParams(string tooltipParams)
        {
            return GetByItemId(tooltipParams.Split(new[] {"/"}, StringSplitOptions.None)[1]);
        }
    }
}
