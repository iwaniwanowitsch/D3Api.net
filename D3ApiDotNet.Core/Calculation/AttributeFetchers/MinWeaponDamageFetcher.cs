using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public class MinWeaponDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return 
                attributes.damageWeaponMin_Arcane +
                attributes.damageWeaponMin_Cold + 
                attributes.damageWeaponMin_Fire + 
                attributes.damageWeaponMin_Holy + 
                attributes.damageWeaponMin_Lightning + 
                attributes.damageWeaponMin_Physical + 
                attributes.damageWeaponMin_Poison;

        }
    }
}