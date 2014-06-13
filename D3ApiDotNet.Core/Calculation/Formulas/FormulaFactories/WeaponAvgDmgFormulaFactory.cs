using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponAvgDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly MinWeaponDamageFetcher _minWeaponDamageFetcher;
        private readonly DeltaWeaponDamageFetcher _deltaWeaponDamageFetcher;

        public WeaponAvgDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, MinWeaponDamageFetcher minWeaponDamageFetcher, DeltaWeaponDamageFetcher deltaWeaponDamageFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
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