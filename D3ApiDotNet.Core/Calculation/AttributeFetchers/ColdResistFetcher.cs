using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public class ColdResistFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.resistance_Cold + attributes.resistance_All;
        }
    }
}