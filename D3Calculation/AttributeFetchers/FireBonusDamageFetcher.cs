using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class FireBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusFire;
        }
    }
}