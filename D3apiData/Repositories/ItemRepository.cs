using System.Drawing;
using D3apiData.API;
using D3apiData.API.Objects.Item;
using D3apiData.API.UrlConstruction;
using System;
using System.IO;

namespace D3apiData.Repositories
{
    public class ItemRepository : JsonObjectRepositoryDecorator<Item>
    {
        private readonly ItemUrlConstructionProvider _urlConstructor;

        public ItemRepository(IReadonlyRepository<Stream, string> readRepo, ItemUrlConstructionProvider urlConstructor) : base(readRepo)
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
