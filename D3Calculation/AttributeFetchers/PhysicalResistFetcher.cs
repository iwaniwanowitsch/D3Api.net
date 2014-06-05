using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class PhysicalResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Physical + attributes.resistance_All;
        }
    }
}