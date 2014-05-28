using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API.Objects.Item;

namespace D3Calculation.BonusDamageCalc
{

    public class ArcaneBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusArcane;
        }
    }

    public class LightningBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusLightning;
        }
    }

    public class FireBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusFire;
        }
    }

    public class PoisonBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusPoison;
        }
    }

    public class HolyBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusHoly;
        }
    }

    public class ColdBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusCold;
        }
    }

    public class PhysicalBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damageDealtPercentBonusPhysical;
        }
    }

    public class ElitesBonusBonusDamageCalculator : BasicDealtBonusDamageCalculator
    {
        protected override ItemValueRange GetBonusDamage(Item item)
        {
            return item.AttributesRaw.damagePercentBonusVsElites;
        }
    }

    public abstract class BasicDealtBonusDamageCalculator : IBonusDamageCalculator
    {
        public virtual double GetBonusDamage(IEnumerable<Item> items)
        {
            return items.Select(o => GetBonusDamage(GetBonusDamage(o))).Sum();
        }

        protected virtual double GetBonusDamage(ItemValueRange range)
        {
            return range == null ? 0 : range.MinMax();
        }

        protected abstract ItemValueRange GetBonusDamage(Item item);
    }

    public interface IBonusDamageCalculator
    {
        double GetBonusDamage(IEnumerable<Item> items);
    }
}
