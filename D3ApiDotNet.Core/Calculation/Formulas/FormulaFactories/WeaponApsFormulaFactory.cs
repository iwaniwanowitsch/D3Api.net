using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class WeaponApsFormulaFactory : AbstractItemsFormulaFactory
    {
        private ItemListDataContainer _weapon1;
        private ItemListDataContainer _weapon2;
        private List<Item> _weapon1List;
        private List<Item> _weapon2List;
        private readonly ApsWeaponFetcher _apsWeaponFetcher;
        private readonly ApsPercentWeaponFetcher _apsPercentWeaponFetcher;

        public WeaponApsFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ApsWeaponFetcher apsWeaponFetcher, ApsPercentWeaponFetcher apsPercentWeaponFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (apsWeaponFetcher == null) throw new ArgumentNullException("apsWeaponFetcher");
            if (apsPercentWeaponFetcher == null) throw new ArgumentNullException("apsPercentWeaponFetcher");
            _apsWeaponFetcher = apsWeaponFetcher;
            _apsPercentWeaponFetcher = apsPercentWeaponFetcher;
        }

        public override ITerm CreateFormula()
        {
            var weaponCount = WeaponList.Count;
            ITerm weaponAps;
            if (weaponCount == 1)
            {
                weaponAps = Factories.BaseFactory.CreateAttributeTerm(ItemListData, _apsWeaponFetcher);
                return Factories.ProductFactory.CreateFormulaTerm(weaponAps,
                Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(ItemListData, _apsPercentWeaponFetcher)));
            }
            else if (weaponCount == 2)
            {
                _weapon1List = new List<Item> { WeaponList[0] };
                _weapon2List = new List<Item> { WeaponList[1] };
                _weapon1 = new ItemListDataContainer(() => _weapon1List);
                _weapon2 = new ItemListDataContainer(() => _weapon2List);
                var weapon1ApsFactory =
                    Factories.ProductFactory.CreateFormulaTerm(
                        Factories.BaseFactory.CreateAttributeTerm(_weapon1, _apsWeaponFetcher),
                        Factories.PercentSumFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(_weapon1, _apsPercentWeaponFetcher)));
                var weapon2ApsFactory =
                    Factories.ProductFactory.CreateFormulaTerm(
                        Factories.BaseFactory.CreateAttributeTerm(_weapon2, _apsWeaponFetcher),
                        Factories.PercentSumFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(_weapon2, _apsPercentWeaponFetcher)));

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
            return new ConstantTerm(0);
        }
    }
}