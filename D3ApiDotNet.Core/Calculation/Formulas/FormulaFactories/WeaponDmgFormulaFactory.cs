using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly PercentWeaponDamageFetcher _percentWeaponDamageFetcher;
        private readonly WeaponAvgDmgFormulaFactory _weaponAvgDmgFactory;
        private readonly BonusAvgDmgFormulaFactory _bonusAvgDmgFactory;

        public WeaponDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, PercentWeaponDamageFetcher percentWeaponDamageFetcher, WeaponAvgDmgFormulaFactory weaponAvgDmgFactory, BonusAvgDmgFormulaFactory bonusAvgDmgFactory)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (percentWeaponDamageFetcher == null) throw new ArgumentNullException("percentWeaponDamageFetcher");
            if (weaponAvgDmgFactory == null) throw new ArgumentNullException("weaponAvgDmgFactory");
            if (bonusAvgDmgFactory == null) throw new ArgumentNullException("bonusAvgDmgFactory");
            _percentWeaponDamageFetcher = percentWeaponDamageFetcher;
            _weaponAvgDmgFactory = weaponAvgDmgFactory;
            _bonusAvgDmgFactory = bonusAvgDmgFactory;
        }

        public override ITerm CreateFormula()
        {
            var weaponAvgDmgFormula = _weaponAvgDmgFactory.CreateFormula();
            var bonusAvgDmgFormula = _bonusAvgDmgFactory.CreateFormula();
            return
                Factories.SumFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(
                        Factories.PercentSumFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _percentWeaponDamageFetcher)),
                        weaponAvgDmgFormula),
                    bonusAvgDmgFormula);
        }
    }
}