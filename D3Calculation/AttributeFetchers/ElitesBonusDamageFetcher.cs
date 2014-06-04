using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ElitesBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damagePercentBonusVsElites;
        }
    }
}