using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ResourceCostReductionFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ResourceCostReductionFetcher _resourceCostReductionFetcher;

        public ResourceCostReductionFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ResourceCostReductionFetcher resourceCostReductionFetcher)
            : base(factories,itemListData)
        {
            if (resourceCostReductionFetcher == null) throw new ArgumentNullException("resourceCostReductionFetcher");
            _resourceCostReductionFetcher = resourceCostReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemListData, _resourceCostReductionFetcher);
        }
    }
}