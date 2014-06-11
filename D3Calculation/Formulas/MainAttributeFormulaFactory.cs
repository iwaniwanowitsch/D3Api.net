using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class MainAttributeFormulaFactory : AttributeFormulaFactory
    {
        public MainAttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList, double heroLvl)
            : base(factories, mainAttributeFetcher, itemList, heroLvl, 3.0)
        {
        }
    }
}