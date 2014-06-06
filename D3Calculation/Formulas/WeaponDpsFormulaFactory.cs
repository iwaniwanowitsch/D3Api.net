using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;

namespace D3Calculation.Formulas
{
    public class WeaponDpsFormulaFactory : AbstractFormulaFactory
    {
        private readonly List<Item> _weapons;
        private readonly WeaponDmgFormulaFactory _weaponDmgFormula;
        private readonly WeaponApsFormulaFactory _weaponApsFactory;

        public WeaponDpsFormulaFactory(List<Item> weapons, ElementalTermFactories factories, WeaponDmgFormulaFactory weaponDmgFormula, WeaponApsFormulaFactory weaponApsFactory)
            : base(factories)
        {
            if (weapons == null) throw new ArgumentNullException("weapons");
            if (weaponDmgFormula == null) throw new ArgumentNullException("weaponDmgFormula");
            if (weaponApsFactory == null) throw new ArgumentNullException("weaponApsFactory");
            _weapons = weapons;
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