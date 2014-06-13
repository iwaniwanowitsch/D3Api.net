using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class BonusAtkSpdFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ApsPercentFetcher _apsPercentFetcher;

        public BonusAtkSpdFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ApsPercentFetcher apsPercentFetcher)
            : base(factories, itemListData)
        {
            if (apsPercentFetcher == null) throw new ArgumentNullException("apsPercentFetcher");
            _apsPercentFetcher = apsPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            //corrected for the moment
            var dualWieldBonus = ItemList.Count(o => o.AttacksPerSecond != null) == 2 ? 0.15 : 0.0;
            //var dualWieldBonus = 0.0;

            return
                Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(ItemListData,
                    _apsPercentFetcher), Factories.BaseFactory.CreateConstantTerm(dualWieldBonus));
        }
    }
}