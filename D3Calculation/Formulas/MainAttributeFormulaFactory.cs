using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class MainAttributeFormulaFactory : AbstractFormulaFactory
    {
        private readonly IAttributeFetcher _mainAttributeFetcher;
        private readonly IList<Item> _itemList;

        public MainAttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList) : base(factories)
        {
            if (mainAttributeFetcher == null) throw new ArgumentNullException("mainAttributeFetcher");
            if (itemList == null) throw new ArgumentNullException("itemList");
            _mainAttributeFetcher = mainAttributeFetcher;
            _itemList = itemList;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _mainAttributeFetcher);
        }
    }
}