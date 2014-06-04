using System.Collections.Generic;
using System.Linq;
using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class CooldownReductionFetcher : BasicAttributeFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.PowerCooldownReductionPercentAll;
        }

        public override double GetBonusDamage(IEnumerable<ItemAttributes> attributes)
        {
            return attributes.Select(o => 1.0 - GetBonusDamage(GetBonusDamage((ItemAttributes) o))).Product();
        }

        protected override double GetBonusDamage(ItemValueRange range)
        {
            var returnval = range == null ? 0.0 : range.GetValue();
            return returnval;
        }

        public override double GetBonusDamage(IEnumerable<Item> items)
        {
            return GetBonusDamage(items.Select(o => o.AttributesRaw)) * GetBonusDamage(items.SelectMany(o => o.Gems.Select(a => a.AttributesRaw)));
        }
    }
}