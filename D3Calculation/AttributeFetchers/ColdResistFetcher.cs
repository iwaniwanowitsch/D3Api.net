using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ColdResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Cold + attributes.resistance_All;
        }
    }
}