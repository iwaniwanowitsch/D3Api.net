using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class WeaponDmgFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _weaponList;
        private readonly PercentWeaponDamageFetcher _percentWeaponDamageFetcher;
        private readonly WeaponAvgDmgFormulaFactory _weaponAvgDmgFactory;
        private readonly BonusAvgDmgFormulaFactory _bonusAvgDmgFactory;

        public WeaponDmgFormulaFactory(ElementalTermFactories factories, IList<Item> weaponList, PercentWeaponDamageFetcher percentWeaponDamageFetcher, WeaponAvgDmgFormulaFactory weaponAvgDmgFactory, BonusAvgDmgFormulaFactory bonusAvgDmgFactory)
            : base(factories)
        {
            if (weaponList == null) throw new ArgumentNullException("weaponList");
            if (percentWeaponDamageFetcher == null) throw new ArgumentNullException("percentWeaponDamageFetcher");
            if (weaponAvgDmgFactory == null) throw new ArgumentNullException("weaponAvgDmgFactory");
            if (bonusAvgDmgFactory == null) throw new ArgumentNullException("bonusAvgDmgFactory");
            _weaponList = weaponList;
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
                            Factories.BaseFactory.CreateAttributeTerm(_weaponList, _percentWeaponDamageFetcher)),
                        weaponAvgDmgFormula),
                    bonusAvgDmgFormula);
        }
    }
}