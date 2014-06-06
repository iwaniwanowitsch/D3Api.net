using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class CriticalHitChanceFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly CritPercentFetcher _critPercentFetcher;

        public CriticalHitChanceFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, CritPercentFetcher critPercentFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (critPercentFetcher == null) throw new ArgumentNullException("critPercentFetcher");
            _itemList = itemList;
            _critPercentFetcher = critPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _critPercentFetcher);
        }
    }
}