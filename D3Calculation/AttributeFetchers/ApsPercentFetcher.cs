using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ApsPercentFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondPercent;
        }
    }
}