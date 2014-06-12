using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VitalityFormulaFactory : AttributeFormulaFactory
    {
        public VitalityFormulaFactory(ElementalTermFactories factories, IAttributeFetcher vitalityFetcher, IList<Item> itemList, double heroLvl)
            : base(factories, vitalityFetcher, itemList, heroLvl, 2.0)
        {
        }
    }
}