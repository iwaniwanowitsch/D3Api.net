using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class DeltaWeaponDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return
                attributes.damageWeaponDelta_Arcane +
                attributes.damageWeaponDelta_Cold +
                attributes.damageWeaponDelta_Fire +
                attributes.damageWeaponDelta_Holy +
                attributes.damageWeaponDelta_Lightning +
                attributes.damageWeaponDelta_Physical +
                attributes.damageWeaponDelta_Poison;
        }
    }
}