using System.Collections.Generic;
using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public abstract class BasicAttributeFetcher : IAttributeFetcher
    {
        public abstract double GetBonusDamage(IEnumerable<Item> items);
        protected abstract double GetBonusDamage(ItemValueRange range);
        protected abstract ItemValueRange GetBonusDamage(ItemAttributes attributes);
        public abstract double GetBonusDamage(IEnumerable<ItemAttributes> attributes);
    }
}