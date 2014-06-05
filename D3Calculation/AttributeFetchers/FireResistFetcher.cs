using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class FireResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Fire + attributes.resistance_All;
        }
    }
}