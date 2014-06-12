using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ElementalDamageFormulaFactory : AbstractFormulaFactory
    {
        private readonly Dictionary<AbstractFormulaFactory, string> _nameLookup;

        public ElementalDamageFormulaFactory(ElementalTermFactories factories, SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher> physDamageFormula, SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher> coldDamageFormula, SingleElementalDamageFormulaFactory<FireBonusDamageFetcher> fireDamageFormula, SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher> lightDamageFormula, SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher> poisonDamageFormula, SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher> arcaneDamageFormula)
            : base(factories)
        {
            if (physDamageFormula == null) throw new ArgumentNullException("physDamageFormula");
            if (coldDamageFormula == null) throw new ArgumentNullException("coldDamageFormula");
            if (fireDamageFormula == null) throw new ArgumentNullException("fireDamageFormula");
            if (lightDamageFormula == null) throw new ArgumentNullException("lightDamageFormula");
            if (poisonDamageFormula == null) throw new ArgumentNullException("poisonDamageFormula");
            if (arcaneDamageFormula == null) throw new ArgumentNullException("arcaneDamageFormula");

            _nameLookup = new Dictionary<AbstractFormulaFactory, string>
            {
                {physDamageFormula,"Physical"},
                {coldDamageFormula,"Cold"},
                {fireDamageFormula,"Fire"},
                {lightDamageFormula,"Lightnig"},
                {poisonDamageFormula,"Poison"},
                {arcaneDamageFormula,"Arcane"}
            };
        }

        public override ITerm CreateFormula()
        {
            return Factories.MaxFactory.CreateFormulaTerm(_nameLookup.Select(o => o.Key.CreateFormula()).ToArray());
        }

        public string MaxElementToString()
        {
            return _nameLookup.First(o => Math.Abs(o.Key.CreateFormula().Evaluate() - this.CreateFormula().Evaluate()) < 0.000001).Value;
        }
    }
}