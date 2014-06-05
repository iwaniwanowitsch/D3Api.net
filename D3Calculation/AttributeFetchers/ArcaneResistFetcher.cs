using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ArcaneResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Arcane + attributes.resistance_All;
        }
    }
}