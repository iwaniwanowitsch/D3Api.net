using System;
using System.Collections.Generic;
using System.Linq;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class BonusAtkSpdFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly ApsPercentFetcher _apsPercentFetcher;

        public BonusAtkSpdFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, ApsPercentFetcher apsPercentFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (apsPercentFetcher == null) throw new ArgumentNullException("apsPercentFetcher");
            _itemList = itemList;
            _apsPercentFetcher = apsPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            //corrected for the moment
            var dualWieldBonus = _itemList.Count(o => o.AttacksPerSecond != null) == 2 ? 0.15 : 0.0;
            //var dualWieldBonus = 0.0;

            return
                Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(_itemList,
                    _apsPercentFetcher), Factories.BaseFactory.CreateConstantTerm(dualWieldBonus));
        }
    }
}