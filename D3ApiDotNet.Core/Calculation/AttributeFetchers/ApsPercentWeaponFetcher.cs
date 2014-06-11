using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public class ApsPercentWeaponFetcher : BasicAttributeAdditiveFetcher 
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondItemPercent;
        }
    }
}