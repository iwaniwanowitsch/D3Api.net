using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ArmorFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.armorItem + attributes.armorBonusItem;
        }
    }
}