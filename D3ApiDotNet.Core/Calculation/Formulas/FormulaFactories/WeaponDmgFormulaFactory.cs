using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly WeaponAvgDmgFormulaFactory _weaponAvgDmgFactory;
        private readonly BonusAvgDmgFormulaFactory _bonusAvgDmgFactory;

        public WeaponDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, WeaponAvgDmgFormulaFactory weaponAvgDmgFactory, BonusAvgDmgFormulaFactory bonusAvgDmgFactory)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (weaponAvgDmgFactory == null) throw new ArgumentNullException("weaponAvgDmgFactory");
            if (bonusAvgDmgFactory == null) throw new ArgumentNullException("bonusAvgDmgFactory");
            _weaponAvgDmgFactory = weaponAvgDmgFactory;
            _bonusAvgDmgFactory = bonusAvgDmgFactory;
        }

        public override ITerm CreateFormula()
        {
            var weaponAvgDmgFormula = _weaponAvgDmgFactory.CreateFormula();
            var bonusAvgDmgFormula = _bonusAvgDmgFactory.CreateFormula();
            return
                Factories.SumFactory.CreateFormulaTerm(
                    weaponAvgDmgFormula,
                    bonusAvgDmgFormula);
        }
    }
}