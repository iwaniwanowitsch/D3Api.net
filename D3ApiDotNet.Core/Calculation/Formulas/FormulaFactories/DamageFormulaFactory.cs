using System;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class DamageFormulaFactory : AbstractFormulaFactory
    {
        private readonly WeaponDpsFormulaFactory _weaponDpsFactory;
        private readonly CriticalHitDamageFormulaFactory _criticalHitDamageFactory;
        private readonly CriticalHitChanceFormulaFactory _criticalHitChanceFactory;
        private readonly BonusAtkSpdFormulaFactory _bonusAtkSpdFactory;
        private readonly MainAttributeFormulaFactory _mainAttributeFactory;

        public DamageFormulaFactory(ElementalTermFactories factories, WeaponDpsFormulaFactory weaponDpsFactory, CriticalHitDamageFormulaFactory criticalHitDamageFactory, CriticalHitChanceFormulaFactory criticalHitChanceFactory, BonusAtkSpdFormulaFactory bonusAtkSpdFactory, MainAttributeFormulaFactory mainAttributeFactory)
            : base(factories)
        {
            if (weaponDpsFactory == null) throw new ArgumentNullException("weaponDpsFactory");
            if (criticalHitDamageFactory == null) throw new ArgumentNullException("criticalHitDamageFactory");
            if (criticalHitChanceFactory == null) throw new ArgumentNullException("criticalHitChanceFactory");
            if (bonusAtkSpdFactory == null) throw new ArgumentNullException("bonusAtkSpdFactory");
            if (mainAttributeFactory == null) throw new ArgumentNullException("mainAttributeFactory");
            _weaponDpsFactory = weaponDpsFactory;
            _criticalHitDamageFactory = criticalHitDamageFactory;
            _criticalHitChanceFactory = criticalHitChanceFactory;
            _bonusAtkSpdFactory = bonusAtkSpdFactory;
            _mainAttributeFactory = mainAttributeFactory;
        }

        public override ITerm CreateFormula()
        {
            var weaponDpsFormula = _weaponDpsFactory.CreateFormula();
            var criticalHitDamageFormula = _criticalHitDamageFactory.CreateFormula();
            var criticalHitChanceFormula = _criticalHitChanceFactory.CreateFormula();
            var bonusAtkSpdFormula = _bonusAtkSpdFactory.CreateFormula();
            var mainAttributeFormula = _mainAttributeFactory.CreateFormula();

            return Factories.ProductFactory.CreateFormulaTerm(weaponDpsFormula,
                Factories.PercentSumFactory.CreateFormulaTerm(bonusAtkSpdFormula),
                Factories.PercentSumFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(criticalHitChanceFormula, criticalHitDamageFormula)),
                Factories.PercentSumFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(mainAttributeFormula,
                        Factories.BaseFactory.CreateConstantTerm(1.0/100))));
        }
    }
}
