using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Item;

namespace D3Calculation.AttributeFetchers
{
    public class ResourceCostReductionFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.ResourceCostReductionPercentAll;
        }
    }

    public class CooldownReductionFetcher : BasicAttributeFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.PowerCooldownReductionPercentAll;
        }

        public override double GetBonusDamage(IEnumerable<ItemAttributes> attributes)
        {
            return attributes.Select(o => 1.0 - GetBonusDamage(GetBonusDamage(o))).Product();
        }

        protected override double GetBonusDamage(ItemValueRange range)
        {
            var returnval = range == null ? 0.0 : range.MinMax();
            return returnval;
        }

        public override double GetBonusDamage(IEnumerable<Item> items)
        {
            return GetBonusDamage(items.Select(o => o.AttributesRaw)) * GetBonusDamage(items.SelectMany(o => o.Gems.Select(a => a.AttributesRaw)));
        }
    }

    public class ApsPercentWeaponFetcher : BasicAttributeAdditiveFetcher 
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondItemPercent;
        }
    }

    public class ApsWeaponFetcher : BasicAttributeAdditiveFetcher
    {

        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondItem;
        }
    }

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

    public class StrengthFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.strengthItem;
        }
    }

    public class DexterityFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.dexterityItem;
        }
    }

    public class IntelligenceFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.intelligenceItem;
        }
    }

    public class ApsFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondItem;
        }
    }

    public class ApsPercentFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.attacksPerSecondPercent;
        }
    }

    public class CritPercentFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.critPercentBonusCapped;
        }
    }

    public class CritDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.critDamagePercent;
        }
    }

    public class ArcaneBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusArcane;
        }
    }

    public class LightningBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusLightning;
        }
    }

    public class FireBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusFire;
        }
    }

    public class PoisonBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusPoison;
        }
    }

    public class HolyBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusHoly;
        }
    }

    public class ColdBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusCold;
        }
    }

    public class PhysicalBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damageDealtPercentBonusPhysical;
        }
    }

    public class ElitesBonusDamageFetcher : BasicAttributeAdditiveFetcher
    {
        protected override ItemValueRange GetBonusDamage(ItemAttributes attributes)
        {
            return attributes.damagePercentBonusVsElites;
        }
    }

    public abstract class BasicAttributeAdditiveFetcher : BasicAttributeFetcher
    {
        public override double GetBonusDamage(IEnumerable<ItemAttributes> attributes)
        {
            return attributes.Select(o => GetBonusDamage(GetBonusDamage(o))).Sum();
        }

        protected override double GetBonusDamage(ItemValueRange range)
        {
            return range == null ? 0.0 : range.MinMax();
        }

        public override double GetBonusDamage(IEnumerable<Item> items)
        {
            return GetBonusDamage(items.Select(o => o.AttributesRaw)) + GetBonusDamage(items.SelectMany(o => o.Gems.Select(a => a.AttributesRaw)));
        }
    }

    public abstract class BasicAttributeFetcher : IAttributeFetcher
    {
        public abstract double GetBonusDamage(IEnumerable<Item> items);
        protected abstract double GetBonusDamage(ItemValueRange range);
        protected abstract ItemValueRange GetBonusDamage(ItemAttributes attributes);
        public abstract double GetBonusDamage(IEnumerable<ItemAttributes> attributes);
    }

    public interface IAttributeFetcher
    {
        double GetBonusDamage(IEnumerable<ItemAttributes> attributes);

        double GetBonusDamage(IEnumerable<Item> items);
    }
}
