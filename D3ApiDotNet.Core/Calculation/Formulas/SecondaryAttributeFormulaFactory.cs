using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class SecondaryAttributeFormulaFactory : AttributeFormulaFactory
    {
        public SecondaryAttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList, double heroLvl)
            : base(factories, mainAttributeFetcher, itemList, heroLvl, 1.0)
        {
        }
    }
}