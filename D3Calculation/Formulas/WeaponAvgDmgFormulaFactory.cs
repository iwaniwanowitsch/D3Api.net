using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class WeaponAvgDmgFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _weaponList;
        private readonly MinWeaponDamageFetcher _minWeaponDamageFetcher;
        private readonly DeltaWeaponDamageFetcher _deltaWeaponDamageFetcher;

        public WeaponAvgDmgFormulaFactory(ElementalTermFactories factories, IList<Item> weaponList, MinWeaponDamageFetcher minWeaponDamageFetcher, DeltaWeaponDamageFetcher deltaWeaponDamageFetcher)
            : base(factories)
        {
            if (weaponList == null) throw new ArgumentNullException("weaponList");
            if (minWeaponDamageFetcher == null) throw new ArgumentNullException("minWeaponDamageFetcher");
            if (deltaWeaponDamageFetcher == null) throw new ArgumentNullException("deltaWeaponDamageFetcher");
            _weaponList = weaponList;
            _minWeaponDamageFetcher = minWeaponDamageFetcher;
            _deltaWeaponDamageFetcher = deltaWeaponDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.ProductFactory.CreateFormulaTerm(
                    Factories.AverageFactory.CreateFormulaTerm(
                        Factories.SumFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(_weaponList, _minWeaponDamageFetcher),
                            Factories.BaseFactory.CreateAttributeTerm(_weaponList, _minWeaponDamageFetcher)),
                        Factories.BaseFactory.CreateAttributeTerm(_weaponList, _deltaWeaponDamageFetcher)
                        ), Factories.BaseFactory.CreateConstantTerm(1.0 / _weaponList.Count));
        }
    }
}