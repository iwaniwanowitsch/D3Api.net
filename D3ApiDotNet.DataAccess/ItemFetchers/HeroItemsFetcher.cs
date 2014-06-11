using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess.Repositories;

namespace D3ApiDotNet.DataAccess.ItemFetchers
{
    public class HeroItemsFetcher
    {
        private readonly ItemRepository _itemRepository;

        public HeroItemsFetcher(ItemRepository itemRepository)
        {
            if (itemRepository == null) throw new ArgumentNullException("itemRepository");
            _itemRepository = itemRepository;
        }

        public List<Item> GetItemsList(Hero hero)
        {
            var items = hero.Items;
            var heroItemsProperties = items.GetType().GetProperties();
            return
                heroItemsProperties.Select(p => p.GetGetMethod().Invoke(items, new object[0]))
                    .Where(o => o != null)
                    .Cast<ItemSummary>()
                    .Select(o => _itemRepository.GetByTooltipParams(o.TooltipParams))
                    .ToList();
        } 
    }
}
