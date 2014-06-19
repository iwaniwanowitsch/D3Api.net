using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public abstract class BasicAttributeAdditiveFetcher : BasicAttributeFetcher
    {
        public override double GetBonusDamage(IEnumerable<ItemAttributes> attributes)
        {
            return attributes.Select(o => GetBonusDamage(GetBonusDamage((ItemAttributes) o))).Sum();
        }

        protected override double GetBonusDamage(ItemValueRange range)
        {
            return range == null ? 0.0 : range.GetValue();
        }

        public override double GetBonusDamage(IEnumerable<Item> items)
        {
            return GetBonusDamage(items.Where(o => o != null).Select(o => o.AttributesRaw)) + GetBonusDamage(items.Where(o => o != null).SelectMany(o => o.Gems.Where(p => p != null).Select(a => a.AttributesRaw)));
        }
    }
}