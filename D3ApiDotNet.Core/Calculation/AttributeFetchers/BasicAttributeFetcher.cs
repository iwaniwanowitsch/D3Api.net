using System.Collections.Generic;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public abstract class BasicAttributeFetcher : IAttributeFetcher
    {
        public abstract double GetBonusDamage(IEnumerable<Item> items);
        protected abstract double GetBonusDamage(ItemValueRange range);
        protected abstract ItemValueRange GetBonusDamage(ItemAttributes attributes);
        public abstract double GetBonusDamage(IEnumerable<ItemAttributes> attributes);
    }
}