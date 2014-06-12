using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ResourceCostReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly ResourceCostReductionFetcher _resourceCostReductionFetcher;

        public ResourceCostReductionFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, ResourceCostReductionFetcher resourceCostReductionFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (resourceCostReductionFetcher == null) throw new ArgumentNullException("resourceCostReductionFetcher");
            _itemList = itemList;
            _resourceCostReductionFetcher = resourceCostReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _resourceCostReductionFetcher);
        }
    }
}