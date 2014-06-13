using System;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponDpsFormulaFactory : AbstractFormulaFactory
    {
        private readonly WeaponDmgFormulaFactory _weaponDmgFormula;
        private readonly WeaponApsFormulaFactory _weaponApsFactory;

        public WeaponDpsFormulaFactory(ElementalTermFactories factories, WeaponDmgFormulaFactory weaponDmgFormula, WeaponApsFormulaFactory weaponApsFactory)
            : base(factories)
        {
            if (weaponDmgFormula == null) throw new ArgumentNullException("weaponDmgFormula");
            if (weaponApsFactory == null) throw new ArgumentNullException("weaponApsFactory");
            _weaponDmgFormula = weaponDmgFormula;
            _weaponApsFactory = weaponApsFactory;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.ProductFactory.CreateFormulaTerm(
                    _weaponDmgFormula.CreateFormula(),
                    _weaponApsFactory.CreateFormula());

        }
    }
}