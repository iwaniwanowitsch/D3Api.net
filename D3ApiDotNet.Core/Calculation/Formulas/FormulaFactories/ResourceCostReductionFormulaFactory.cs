using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class ResourceCostReductionFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ResourceCostReductionFetcher _resourceCostReductionFetcher;

        public ResourceCostReductionFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ResourceCostReductionFetcher resourceCostReductionFetcher)
            : base(factories,itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (resourceCostReductionFetcher == null) throw new ArgumentNullException("resourceCostReductionFetcher");
            _resourceCostReductionFetcher = resourceCostReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemListData, _resourceCostReductionFetcher);
        }
    }
}