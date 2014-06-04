using System;
using System.Collections.Generic;
using System.Linq;
using D3apiData.API.Objects.Item;

namespace D3Calculation.ItemFetchers
{
    public class SetAttributesFetcher : ISetAttributesFetcher
    {
        public IEnumerable<ItemAttributes> GetSetAttributes(IEnumerable<Item> items)
        {
            var setItems = items.Where(o => o.Set != null);
            var royal = items.Count(o => o.AttributesRaw.AttributeSetItemDiscount != null) > 0;
            var checkedSetItems = new Dictionary<Item, int>();
            foreach (var setItem in setItems)
            {
                if (checkedSetItems.Count(o => o.Key.Set.Slug == setItem.Set.Slug) < 1)
                    checkedSetItems.Add(setItem, setItems.Count(o => o.Set.Slug == setItem.Set.Slug));
            }
            var attributes = new List<ItemAttributes>();
            foreach (var set in checkedSetItems)
            {
                attributes.AddRange(from rank in set.Key.Set.Ranks where set.Value >= 2 && rank.Required - (royal ? 1 : 0) <= set.Value select rank.AttributesRaw);
            }
            return attributes;
        }
    }

    interface ISetAttributesFetcher
    {
        IEnumerable<ItemAttributes> GetSetAttributes(IEnumerable<Item> items);
    }
}
