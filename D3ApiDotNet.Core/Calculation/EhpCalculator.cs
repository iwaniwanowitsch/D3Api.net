using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation
{
    public class EhpCalculator
    {
        private const double VitalityBaseConst = 7;
        private const double DexterityBaseConst = 7;
        private const double IntelligenceBaseConst = 7;
        private const double StrengthBaseConst = 7;

        private int dexPerLevel = 1;
        private int intPerLevel = 1;
        private int strengthPerLevel = 1;

        private List<Item> _itemList;

        public EhpCalculator(List<Item> itemList, HeroClass heroClass)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            ItemList = itemList;
            if (heroClass == HeroClass.Wizard || heroClass == HeroClass.Witchdoctor)
                intPerLevel = 3;
            if (heroClass == HeroClass.Monk || heroClass == HeroClass.Demonhunter)
                intPerLevel = 3;
            if (heroClass == HeroClass.Barbarian || heroClass == HeroClass.Crusader)
                intPerLevel = 3;
        }

        public List<Item> ItemList
        {
            get { return _itemList; }
            set { if (value != null) _itemList = value; }
        }

        public double GetEhp(double herolvl)
        {
            var vitalityFetcher = new VitalityFetcher();
            var dexterityFetcher = new DexterityFetcher();
            var intelligenceFetcher = new IntelligenceFetcher();
            var strengthFetcher = new StrengthFetcher();
            var hpPercentFetcher = new HpPercentFetcher();
            var armorFetcher = new ArmorFetcher();
            var physResistFetcher = new PhysicalResistFetcher();
            var coldResistFetcher = new ColdResistFetcher();
            var fireResistFetcher = new FireResistFetcher();
            var lightResistFetcher = new LightningResistFetcher();
            var poisonResistFetcher = new PoisonResistFetcher();
            var arcaneResistFetcher = new ArcaneResistFetcher();
            var meleeReductionPercentFetcher = new MeleeDamageReductionFetcher();
            var rangedReductionPercentFetcher = new RangedDamageReductionFetcher();
            var elitesReductionPercentFetcher = new ElitesDamageReductionFetcher();

            var setAttributes = ItemList.GetSetAttributes().ToList();

            var vitality = vitalityFetcher.GetBonusDamage(ItemList) + vitalityFetcher.GetBonusDamage(setAttributes) + herolvl * 2 + VitalityBaseConst;
            var dexterity = dexterityFetcher.GetBonusDamage(ItemList) + dexterityFetcher.GetBonusDamage(setAttributes) + herolvl * dexPerLevel + DexterityBaseConst;
            var hpPercent = hpPercentFetcher.GetBonusDamage(ItemList) + hpPercentFetcher.GetBonusDamage(setAttributes);
            var strength = strengthFetcher.GetBonusDamage(ItemList) + strengthFetcher.GetBonusDamage(setAttributes) +
                           herolvl*strengthPerLevel + StrengthBaseConst;
            var armor = armorFetcher.GetBonusDamage(ItemList) + armorFetcher.GetBonusDamage(setAttributes) + strength;
            var intelligence = intelligenceFetcher.GetBonusDamage(ItemList) +
                               intelligenceFetcher.GetBonusDamage(setAttributes) + herolvl * intPerLevel + IntelligenceBaseConst;
            var physResist = physResistFetcher.GetBonusDamage(ItemList) +
                             physResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var coldResist = coldResistFetcher.GetBonusDamage(ItemList) +
                             coldResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var fireResist = fireResistFetcher.GetBonusDamage(ItemList) +
                             fireResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var lightResist = lightResistFetcher.GetBonusDamage(ItemList) +
                              lightResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var poisonResist = poisonResistFetcher.GetBonusDamage(ItemList) +
                               poisonResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var arcaneResist = arcaneResistFetcher.GetBonusDamage(ItemList) +
                               arcaneResistFetcher.GetBonusDamage(setAttributes) + intelligence / 10;
            var meleeReductionPercent = meleeReductionPercentFetcher.GetBonusDamage(ItemList) +
                                        meleeReductionPercentFetcher.GetBonusDamage(setAttributes);
            var rangedReductionPercent = rangedReductionPercentFetcher.GetBonusDamage(ItemList) +
                                         rangedReductionPercentFetcher.GetBonusDamage(setAttributes);
            var elitesReductionPercent = elitesReductionPercentFetcher.GetBonusDamage(ItemList) +
                                         elitesReductionPercentFetcher.GetBonusDamage(setAttributes);
            return GetEhp(herolvl, vitality, hpPercent, armor, dexterity, physResist, coldResist, fireResist,
                lightResist, poisonResist, arcaneResist, meleeReductionPercent, rangedReductionPercent,
                elitesReductionPercent);
        }

        public double GetEhp(double herolvl, double vitality, double hpPercent, double armor, double dexterity, double physResist, double coldResist, double fireResist, double lightResist, double poisonResist, double arcaneResist, double meleeReductionPercent, double rangedReductionPercent, double vsEliteReductionPercent)
        {
            // maximum life calculation
            var maxlife = 36 + 4*herolvl;
            if (herolvl < 35)
                maxlife += 10*vitality;
            else if (herolvl <= 60)
                maxlife += (herolvl - 25)*vitality;
            else
                maxlife += 80*vitality;
            maxlife = maxlife*(1 + hpPercent);
            
            // damage reduction armor
            var dra = 1 - armor / (50*herolvl + armor);
            // damage reduction ressistances
            var resistAvg = (physResist + coldResist + fireResist + lightResist + poisonResist + arcaneResist) / 6;
            var drr = 1 - resistAvg / (5*herolvl + resistAvg);
            // damage reduction dodge
            var dodge = 0.0;
            if (herolvl <= 60)
                dodge = dexterity*0.0097;
            else if (herolvl > 60)
                dodge = dexterity*0.0046;
            var drd = 1 - dodge/100;
            // damage reduction other factors
            var dro = 1 - (meleeReductionPercent + rangedReductionPercent + vsEliteReductionPercent) / 3;
            // actual hp
            return maxlife / (dra * drr * drd * dro);
        }
    }
}
