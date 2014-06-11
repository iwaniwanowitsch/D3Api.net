using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VitalityFormulaFactory : AttributeFormulaFactory
    {
        public VitalityFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList, double heroLvl)
            : base(factories, mainAttributeFetcher, itemList, heroLvl, 2.0)
        {
        }
    }
}