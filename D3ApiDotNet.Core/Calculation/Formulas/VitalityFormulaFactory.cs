using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VitalityFormulaFactory : AttributeFormulaFactory
    {
        public VitalityFormulaFactory(ElementalTermFactories factories, IAttributeFetcher vitalityFetcher, IItemListDataContainer itemListData, double heroLvl)
            : base(factories, vitalityFetcher, itemListData, heroLvl, 2.0)
        {
        }
    }
}