using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class LightningResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Lightning + attributes.resistance_All;
        }
    }
}