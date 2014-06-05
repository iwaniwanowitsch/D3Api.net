using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class PoisonResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Poison + attributes.resistance_All;
        }
    }
}