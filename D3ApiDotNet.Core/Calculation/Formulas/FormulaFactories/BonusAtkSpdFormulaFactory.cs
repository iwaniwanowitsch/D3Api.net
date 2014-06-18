using System;
using System.Linq;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class BonusAtkSpdFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ApsPercentFetcher _apsPercentFetcher;

        public BonusAtkSpdFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ApsPercentFetcher apsPercentFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (apsPercentFetcher == null) throw new ArgumentNullException("apsPercentFetcher");
            _apsPercentFetcher = apsPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            //corrected for the moment
            var dualWieldBonus = WeaponList.Count == 2 ? 0.15 : 0.0;
            //var dualWieldBonus = 0.0;

            return
                Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(ItemListData,
                    _apsPercentFetcher), Factories.BaseFactory.CreateConstantTerm(dualWieldBonus));
        }
    }
}