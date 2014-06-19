using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core
{
    public static class EnumerableExtension
    {
        public static double Product(this IEnumerable<double> enumerable)
        {
            return enumerable.Aggregate(1.0, (accumulator, current) => accumulator * current);
        }

        public static IEnumerable<ItemAttributes> GetSetAttributes(this IEnumerable<Item> items)
        {
            var setItems = items.Where(o => o != null && o.Set != null);
            var royal = items.Where(o => o != null).Count(o => o.AttributesRaw.AttributeSetItemDiscount != null) > 0;
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

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            foreach (var element in source)
            {
                action(element);
            }
        }
    }
}
