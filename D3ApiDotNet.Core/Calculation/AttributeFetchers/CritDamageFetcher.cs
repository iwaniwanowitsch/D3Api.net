using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public class CritDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.critDamagePercent;
        }
    }
}