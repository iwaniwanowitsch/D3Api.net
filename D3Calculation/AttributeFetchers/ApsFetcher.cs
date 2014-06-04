using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ApsFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondItem;
        }
    }
}