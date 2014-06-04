using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class LightningBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusLightning;
        }
    }
}