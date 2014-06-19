using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponAvgDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly MinWeaponDamageFetcher _minWeaponDamageFetcher;
        private readonly DeltaWeaponDamageFetcher _deltaWeaponDamageFetcher;
        private readonly PercentWeaponDamageFetcher _percentWeaponDamageFetcher;

        public WeaponAvgDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, MinWeaponDamageFetcher minWeaponDamageFetcher, DeltaWeaponDamageFetcher deltaWeaponDamageFetcher, PercentWeaponDamageFetcher percentWeaponDamageFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (minWeaponDamageFetcher == null) throw new ArgumentNullException("minWeaponDamageFetcher");
            if (deltaWeaponDamageFetcher == null) throw new ArgumentNullException("deltaWeaponDamageFetcher");
            if (percentWeaponDamageFetcher == null) throw new ArgumentNullException("percentWeaponDamageFetcher");
            _minWeaponDamageFetcher = minWeaponDamageFetcher;
            _deltaWeaponDamageFetcher = deltaWeaponDamageFetcher;
            _percentWeaponDamageFetcher = percentWeaponDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            if (WeaponList.Count == 2)
            {
                var weapon1List = new List<Item> { WeaponList[0] };
                var weapon2List = new List<Item> { WeaponList[1] };
                var weapon1 = new ItemListDataContainer(() => weapon1List);
                var weapon2 = new ItemListDataContainer(() => weapon2List);
                return
                    Factories.ProductFactory.CreateFormulaTerm(
                        Factories.SumFactory.CreateFormulaTerm(
                            Factories.ProductFactory.CreateFormulaTerm(
                                Factories.AverageFactory.CreateFormulaTerm(
                                    Factories.SumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(weapon1, _minWeaponDamageFetcher),
                                        Factories.BaseFactory.CreateAttributeTerm(weapon1, _minWeaponDamageFetcher)),
                                    Factories.BaseFactory.CreateAttributeTerm(weapon1, _deltaWeaponDamageFetcher)
                                    ), Factories.PercentSumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(weapon1,
                                            _percentWeaponDamageFetcher))
                                ),
                            Factories.ProductFactory.CreateFormulaTerm(
                                Factories.AverageFactory.CreateFormulaTerm(
                                    Factories.SumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(weapon2, _minWeaponDamageFetcher),
                                        Factories.BaseFactory.CreateAttributeTerm(weapon2, _minWeaponDamageFetcher)),
                                    Factories.BaseFactory.CreateAttributeTerm(weapon2, _deltaWeaponDamageFetcher)
                                    ), Factories.PercentSumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(weapon2,
                                            _percentWeaponDamageFetcher))
                                )
                            ), Factories.BaseFactory.CreateConstantTerm(1.0 / WeaponList.Count));
            }
            return
                Factories.ProductFactory.CreateFormulaTerm(
                    Factories.ProductFactory.CreateFormulaTerm(
                                Factories.AverageFactory.CreateFormulaTerm(
                                    Factories.SumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minWeaponDamageFetcher),
                                        Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minWeaponDamageFetcher)),
                                    Factories.BaseFactory.CreateAttributeTerm(ItemListData, _deltaWeaponDamageFetcher)
                                    ), Factories.PercentSumFactory.CreateFormulaTerm(
                                        Factories.BaseFactory.CreateAttributeTerm(ItemListData,
                                            _percentWeaponDamageFetcher))
                                ), Factories.BaseFactory.CreateConstantTerm(1.0 / WeaponList.Count));
        }
    }
}