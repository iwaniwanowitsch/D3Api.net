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

        private readonly D3Data _data;

        private readonly Dictionary<HeroClass,IAttributeFetcher> _heroMainStatFetcherLookup = new Dictionary<HeroClass, IAttributeFetcher>
        {
            {HeroClass.Barbarian, new StrengthFetcher()},
            {HeroClass.Crusader, new StrengthFetcher()},
            {HeroClass.Demonhunter, new DexterityFetcher()},
            {HeroClass.Monk, new DexterityFetcher()},
            {HeroClass.Witchdoctor, new IntelligenceFetcher()},
            {HeroClass.Wizard, new IntelligenceFetcher()}
        };

        public DamageCalculator(D3Data data)
        {
            if (data == null) throw new ArgumentNullException("data");
            _data = data;
        }

        public HeroDamageData GetHeroDamage(Hero hero)
        {
            var profileDps = hero.Stats.Damage;

            // stats fetchers
            var mainStatFetcher = _heroMainStatFetcherLookup[hero.HeroClass];
            var atkSpdPercentFetcher = new ApsPercentFetcher();
            var ccPercentFetcher = new CritPercentFetcher();
            var cdPercentFetcher = new CritDamageFetcher();
            var vsElitesPercentFetcher = new ElitesBonusDamageFetcher();
            var cooldownReductionFetcher = new CooldownReductionFetcher();
            var resourceCostReductionFetcher = new ResourceCostReductionFetcher();

            // hero items list
            var itemListFetcher = new HeroItemsFetcher(_data);
            var itemList = itemListFetcher.GetItemsList(hero);
            // hero stats, without sets
            var mainStats = mainStatFetcher.GetBonusDamage(itemList) + hero.Level * 3 + MainStatsDefaultConst;
            var atkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(itemList) + AtkSpdPercentDefaultConst;
            var ccPercent = ccPercentFetcher.GetBonusDamage(itemList) + CcPercentDefaultConst;
            var cdPercent = cdPercentFetcher.GetBonusDamage(itemList) + CdPercentDefaultConst;
            var vsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(itemList);
            var cooldownReduction = cooldownReductionFetcher.GetBonusDamage(itemList);
            var resourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(itemList);

            // hero setAttributes list
            var setAttributesFetcher = new SetAttributesCalculator();
            var setAttributes = setAttributesFetcher.GetSetAttributes(itemList);
            // hero stats from sets only
            var setMainStats = mainStatFetcher.GetBonusDamage(setAttributes);
            var setAtkSpdPercent = atkSpdPercentFetcher.GetBonusDamage(setAttributes);
            var setCcPercent = ccPercentFetcher.GetBonusDamage(setAttributes);
            var setCdPercent = cdPercentFetcher.GetBonusDamage(setAttributes);
            var setVsElitesPercent = vsElitesPercentFetcher.GetBonusDamage(setAttributes);
            var setCooldownReduction = cooldownReductionFetcher.GetBonusDamage(setAttributes);
            var setResourceCostReduction = resourceCostReductionFetcher.GetBonusDamage(setAttributes);

            // elemental damage
            var attributesList = itemList.Select(o => o.AttributesRaw).Concat(setAttributes);
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
