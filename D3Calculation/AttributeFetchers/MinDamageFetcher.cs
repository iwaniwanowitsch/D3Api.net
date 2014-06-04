using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class MinDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return
                attributes.damageMin_Arcane +
                attributes.damageMin_Cold +
                attributes.damageMin_Fire +
                attributes.damageMin_Holy +
                attributes.damageMin_Lightning +
                attributes.damageMin_Physical +
                attributes.damageMin_Poison;
        }
    }
}