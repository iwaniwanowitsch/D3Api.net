using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using D3apiData.API;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;
using D3Calculation.BonusDamageCalc;
using D3Calculation.SetCalc;

namespace D3Calculation
{
    class DamageCalculator
    {
        private const double AtkSpdPercentDefaultConst = 0;
        private const double CcPercentDefaultConst = 0.05;
        private const double CdPercentDefaultConst = 0.5;
        private const double MainStatsDefaultConst = 7;

        private List<Item> _itemList;
        private readonly IAttributeFetcher _mainStatFetcher;

        public DamageCalculator(List<Item> itemList, IAttributeFetcher mainStatFetcher)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (mainStatFetcher == null) throw new ArgumentNullException("mainStatFetcher");
            _itemList = itemList;
            _mainStatFetcher = mainStatFetcher;
        }

        public List<Item> ItemList
        {
            get
            {
                return _itemList;
            }
            set
            {
                if (value == null)
                    return;
                _itemList = value;
            }
        }

        /* 
        public HeroDamageData GetHeroDamage(int heroLvl)
        {
            // stats fetchers
            var atkSpdPercentFetcher = new ApsPercentFetcher();
            var ccPercentFetcher = new CritPercentFetcher();
            var cdPercentFetcher = new CritDamageFetcher();
            var vsElitesPercentFetcher = new ElitesBonusDamageFetcher();
            var cooldownReductionFetcher = new CooldownReductionFetcher();
            var resourceCostReductionFetcher = new ResourceCostReductionFetcher();

            // hero stats, without sets
            var mainStats = _mainStatFetcher.GetBonusDamage(ItemList) + heroLvl * 3 + MainStatsDefaultConst;
            var atkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(ItemList) + AtkSpdPercentDefaultConst;
            var ccPercent = ccPercentFetcher.GetBonusDamage(ItemList) + CcPercentDefaultConst;
            var cdPercent = cdPercentFetcher.GetBonusDamage(ItemList) + CdPercentDefaultConst;
            var vsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(ItemList);
            var cooldownReduction = cooldownReductionFetcher.GetBonusDamage(ItemList);
            var resourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(ItemList);

            // hero setAttributes list
            var setAttributesFetcher = new SetAttributesCalculator();
            var setAttributes = setAttributesFetcher.GetSetAttributes(ItemList);
            // hero stats from sets only
            var setMainStats = _mainStatFetcher.GetBonusDamage(setAttributes);
            var setAtkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(setAttributes);
            var setCcPercent = ccPercentFetcher.GetBonusDamage(setAttributes);
            var setCdPercent = cdPercentFetcher.GetBonusDamage(setAttributes);
            var setVsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(setAttributes);
            var setCooldownReduction = cooldownReductionFetcher.GetBonusDamage(setAttributes);
            var setResourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(setAttributes);

            // elemental damage
            var attributesList = ItemList.Select(o => o.AttributesRaw).Concat(setAttributes);
            var elementalBonusDmgCalcList = new Dictionary<string, IAttributeFetcher>
                {
                    {"Arcane", new ArcaneBonusDamageFetcher()},
                    {"Cold", new ColdBonusDamageFetcher()},
                    {"Fire", new FireBonusDamageFetcher()},
                    {"Holy", new HolyBonusDamageFetcher()},
                    {"Lightning", new LightningBonusDamageFetcher()},
                    {"Physical", new PhysicalBonusDamageFetcher()},
                    {"Poison", new PoisonBonusDamageFetcher()}
                };
            var elementalBonusDmgList =
                elementalBonusDmgCalcList.Select(
                    pair => new KeyValuePair<string, double>(pair.Key, pair.Value.GetBonusDamage(attributesList))).ToList();
            var elementalBonusValue = elementalBonusDmgList.Max(o => o.Value);
            var elementalBonusName = elementalBonusDmgList.FirstOrDefault(o => Math.Abs(o.Value - elementalBonusValue) < 0.0001).Key;

            // weapon dmg
            var weaponCount = ItemList.Select(o => o.AttacksPerSecond).Where(o => o != null).ToArray().Length;

            // weapon dmg fetcher
            var weaponMinDmgFetcher = new MinWeaponDamageFetcher();
            var weaponDeltaDmgFetcher = new DeltaWeaponDamageFetcher();
            var weaponApsFetcher = new ApsWeaponFetcher();
            var weaponApsPercentFetcher = new ApsPercentFetcher();

            double weaponMinDmg;
            double weaponDeltaDmg;
            double weaponAps;
            double weaponApsPercent;
            double weaponDps = 0;

            if (weaponCount == 1)
            {
                var weapon = ItemList.Where(o => o.AttacksPerSecond != null);
                // weapon dmg
                weaponMinDmg = weaponMinDmgFetcher.GetBonusDamage(weapon);
                weaponDeltaDmg = weaponDeltaDmgFetcher.GetBonusDamage(weapon);
                weaponAps = weaponApsFetcher.GetBonusDamage(weapon);
                weaponApsPercent = weaponApsPercentFetcher.GetBonusDamage(weapon);

                weaponDps = (2 * weaponMinDmg + weaponDeltaDmg) / 2 * weaponAps * (1 + weaponApsPercent);
            }
            else if (weaponCount == 2) {
                var weapon1 = ItemList.Where(o => o.AttacksPerSecond != null).ToArray()[0];
                var weapon2 = ItemList.Where(o => o.AttacksPerSecond != null).ToArray()[1];
                // weapon dmg
                weaponMinDmg = weaponMinDmgFetcher.GetBonusDamage(new List<Item> { weapon1 }) + weaponMinDmgFetcher.GetBonusDamage(new List<Item> { weapon2 });
                weaponDeltaDmg = weaponDeltaDmgFetcher.GetBonusDamage(new List<Item> { weapon1 }) + weaponDeltaDmgFetcher.GetBonusDamage(new List<Item> { weapon2 });
                var weapon1Aps = weaponApsFetcher.GetBonusDamage(new List<Item> { weapon1 });
                var weapon2Aps = weaponApsFetcher.GetBonusDamage(new List<Item> { weapon1 });
                var weapon1Dps = weapon1Aps * (1 + weaponApsPercentFetcher.GetBonusDamage(new List<Item> { weapon1 }));
                var weapon2Dps = weapon2Aps * (1 + weaponApsPercentFetcher.GetBonusDamage(new List<Item> { weapon2 }));
                weaponDps = 2 * weapon1Dps * weapon2Dps / (weapon1Dps + weapon2Dps);

                weaponDps = (weaponMinDmg + 2 * 62 + weaponMinDmg + weaponDeltaDmg + 2 * 132) / 4 * weaponDps;
            }

            var correctedDps = weaponDps * (1 + atkSpdPercent + setAtkSpdPercent) * (1 + (ccPercent + setCcPercent) * (cdPercent + setCdPercent)) * (1 + (mainStats + setMainStats) / 100);

            return new HeroDamageData(correctedDps, correctedDps, elementalBonusValue, elementalBonusName, vsElitesPercent + setVsElitesPercent, 0, 1 - cooldownReduction * setCooldownReduction, resourceCostReduction + setResourceCostReduction, ccPercent + setCcPercent, cdPercent + setCdPercent, atkSpdPercent + setAtkSpdPercent, mainStats + setMainStats);
        }
        */

        public HeroDamageData GetHeroDamage(int heroLvl, double profileDps)
        {
            // stats fetchers
            var atkSpdPercentFetcher = new ApsPercentFetcher();
            var ccPercentFetcher = new CritPercentFetcher();
            var cdPercentFetcher = new CritDamageFetcher();
            var vsElitesPercentFetcher = new ElitesBonusDamageFetcher();
            var cooldownReductionFetcher = new CooldownReductionFetcher();
            var resourceCostReductionFetcher = new ResourceCostReductionFetcher();

            // hero stats, without sets
            var mainStats = _mainStatFetcher.GetBonusDamage(ItemList) + heroLvl * 3 + MainStatsDefaultConst;
            var atkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(ItemList) + AtkSpdPercentDefaultConst;
            var ccPercent = ccPercentFetcher.GetBonusDamage(ItemList) + CcPercentDefaultConst;
            var cdPercent = cdPercentFetcher.GetBonusDamage(ItemList) + CdPercentDefaultConst;
            var vsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(ItemList);
            var cooldownReduction = cooldownReductionFetcher.GetBonusDamage(ItemList);
            var resourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(ItemList);

            // hero setAttributes list
            var setAttributesFetcher = new SetAttributesCalculator();
            var setAttributes = setAttributesFetcher.GetSetAttributes(ItemList);
            // hero stats from sets only
            var setMainStats = _mainStatFetcher.GetBonusDamage(setAttributes);
            var setAtkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(setAttributes);
            var setCcPercent = ccPercentFetcher.GetBonusDamage(setAttributes);
            var setCdPercent = cdPercentFetcher.GetBonusDamage(setAttributes);
            var setVsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(setAttributes);
            var setCooldownReduction = cooldownReductionFetcher.GetBonusDamage(setAttributes);
            var setResourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(setAttributes);

            // elemental damage
            var attributesList = ItemList.Select(o => o.AttributesRaw).Concat(setAttributes);
            var elementalBonusDmgCalcList = new Dictionary<string, IAttributeFetcher>
                {
                    {"Arcane", new ArcaneBonusDamageFetcher()},
                    {"Cold", new ColdBonusDamageFetcher()},
                    {"Fire", new FireBonusDamageFetcher()},
                    {"Holy", new HolyBonusDamageFetcher()},
                    {"Lightning", new LightningBonusDamageFetcher()},
                    {"Physical", new PhysicalBonusDamageFetcher()},
                    {"Poison", new PoisonBonusDamageFetcher()}
                };
            var elementalBonusDmgList =
                elementalBonusDmgCalcList.Select(
                    pair => new KeyValuePair<string, double>(pair.Key, pair.Value.GetBonusDamage(attributesList))).ToList();
            var elementalBonusValue = elementalBonusDmgList.Max(o => o.Value);
            var elementalBonusName = elementalBonusDmgList.FirstOrDefault(o => Math.Abs(o.Value - elementalBonusValue) < 0.0001).Key;

            // corrected Dps
            var correctedDps = profileDps*
                               (1 + setCcPercent*setCdPercent/(1 + ccPercent*cdPercent))*
                               (1 + setAtkSpdPercent/(1 + atkSpdPercent))*
                               (1 + setMainStats/(100 + mainStats));

            return new HeroDamageData(profileDps, correctedDps, elementalBonusValue, elementalBonusName, vsElitesPercent + setVsElitesPercent, 0, 1 - cooldownReduction * setCooldownReduction, resourceCostReduction + setResourceCostReduction, ccPercent+setCcPercent, cdPercent+setCdPercent, atkSpdPercent+setAtkSpdPercent, mainStats+setMainStats);
        }

        public double GetDps(double weapon1MinDmg, double weapon1MaxDmg, double weapon1Aps, double weapon2MinDmg, double weapon2MaxDmg, double weapon2Aps, double bonusDamageMin, double bonusDamageMax, double primaryAttribute, double attackSpeed, double criticalHitChance, double criticalHitDamage, double passiveDamage)
        {
            var weaponDmg = ((weapon1MinDmg + weapon1MaxDmg) / 2 + (weapon2MinDmg + weapon2MaxDmg) / 2) / 2 + (bonusDamageMin + bonusDamageMax) / 2;
            var aps = 2 * weapon1Aps * weapon2Aps / (weapon1Aps + weapon2Aps);
            return weaponDmg * aps * (1 + primaryAttribute / 100) * (1 + attackSpeed) * (1 + criticalHitChance * criticalHitDamage) * (1 + passiveDamage);
        }

        public double GetDps(double weaponMinDmg, double weaponMaxDmg, double weaponAps, double bonusDamageMin, double bonusDamageMax, double primaryAttribute, double attackSpeed, double criticalHitChance, double criticalHitDamage, double passiveDamage)
        {
            var weaponDmg = (weaponMinDmg + weaponMaxDmg) / 2 + (bonusDamageMin + bonusDamageMax) / 2;
            return weaponDmg * weaponAps * (1 + primaryAttribute / 100) * (1 + attackSpeed) * (1 + criticalHitChance * criticalHitDamage) * (1 + passiveDamage);
        }
    }
}
