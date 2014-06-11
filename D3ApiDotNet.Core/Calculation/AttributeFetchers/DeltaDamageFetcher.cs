using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.AttributeFetchers
{
    public class DeltaDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return
                attributes.damageDelta_Arcane +
                attributes.damageDelta_Cold +
                attributes.damageDelta_Fire +
                attributes.damageDelta_Holy +
                attributes.damageDelta_Lightning +
                attributes.damageDelta_Physical +
                attributes.damageDelta_Poison;
        }
    }
}