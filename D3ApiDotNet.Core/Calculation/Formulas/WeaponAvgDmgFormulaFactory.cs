using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class WeaponAvgDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly MinWeaponDamageFetcher _minWeaponDamageFetcher;
        private readonly DeltaWeaponDamageFetcher _deltaWeaponDamageFetcher;

        public WeaponAvgDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer weaponListData, MinWeaponDamageFetcher minWeaponDamageFetcher, DeltaWeaponDamageFetcher deltaWeaponDamageFetcher)
            : base(factories, weaponListData)
        {
            if (minWeaponDamageFetcher == null) throw new ArgumentNullException("minWeaponDamageFetcher");
            if (deltaWeaponDamageFetcher == null) throw new ArgumentNullException("deltaWeaponDamageFetcher");
            _minWeaponDamageFetcher = minWeaponDamageFetcher;
            _deltaWeaponDamageFetcher = deltaWeaponDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.ProductFactory.CreateFormulaTerm(
                    Factories.AverageFactory.CreateFormulaTerm(
                        Factories.SumFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minWeaponDamageFetcher),
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minWeaponDamageFetcher)),
                        Factories.BaseFactory.CreateAttributeTerm(ItemListData, _deltaWeaponDamageFetcher)
                        ), Factories.BaseFactory.CreateConstantTerm(1.0 / WeaponList.Count));
        }
    }
}