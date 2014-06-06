using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class WeaponApsFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _weaponList;
        private readonly ApsWeaponFetcher _apsWeaponFetcher;
        private readonly ApsPercentWeaponFetcher _apsPercentWeaponFetcher;

        public WeaponApsFormulaFactory(ElementalTermFactories factories, IList<Item> weaponList, ApsWeaponFetcher apsWeaponFetcher, ApsPercentWeaponFetcher apsPercentWeaponFetcher)
            : base(factories)
        {
            if (weaponList == null) throw new ArgumentNullException("weaponList");
            if (apsWeaponFetcher == null) throw new ArgumentNullException("apsWeaponFetcher");
            if (apsPercentWeaponFetcher == null) throw new ArgumentNullException("apsPercentWeaponFetcher");
            _weaponList = weaponList;
            _apsWeaponFetcher = apsWeaponFetcher;
            _apsPercentWeaponFetcher = apsPercentWeaponFetcher;
        }

        public override ITerm CreateFormula()
        {
            var weaponCount = _weaponList.Count;
            ITerm weaponAps;
            if (weaponCount == 1)
            {
                weaponAps = Factories.BaseFactory.CreateAttributeTerm(_weaponList, _apsWeaponFetcher);
                return Factories.ProductFactory.CreateFormulaTerm(weaponAps,
                Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(_weaponList, _apsPercentWeaponFetcher)));
            }
            else
            {
                var weapon1List = new List<Item> { _weaponList[0]};
                var weapon2List = new List<Item> { _weaponList[1]};
                var weapon1ApsFactory = Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(weapon1List, _apsWeaponFetcher), Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(weapon1List, _apsPercentWeaponFetcher)));
                var weapon2ApsFactory = Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(weapon2List, _apsWeaponFetcher), Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(weapon2List, _apsPercentWeaponFetcher)));

                weaponAps = Factories.ProductFactory.CreateFormulaTerm(
                    Factories.BaseFactory.CreateConstantTerm(2.0),
                    weapon1ApsFactory,
                    weapon2ApsFactory,
                    Factories.DivisionFactory.CreateFormulaTerm(
                    Factories.SumFactory.CreateFormulaTerm(
                        weapon1ApsFactory,
                        weapon2ApsFactory
                        )
                    ));
                return weaponAps;
            }
        }
    }
}