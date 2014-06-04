using System;
using System.Collections.Generic;
using System.Linq;
using D3apiData.API;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;

namespace D3Calculation.ItemFetchers
{
    class HeroItemsFetcher
    {
        private readonly D3Data _data;

        public HeroItemsFetcher(D3Data data)
        {
            if (data == null) throw new ArgumentNullException("data");
            _data = data;
        }

        public List<Item> GetItemsList(Hero hero)
        {
            var items = hero.Items;
            var heroItemsProperties = items.GetType().GetProperties();
            return
                heroItemsProperties.Select(p => p.GetGetMethod().Invoke(items, new object[0]))
                    .Where(o => o != null)
                    .Cast<ItemSummary>()
                    .Select(o => _data.GetItemByTooltipParams(o.TooltipParams))
                    .ToList();
        } 
    }
}
