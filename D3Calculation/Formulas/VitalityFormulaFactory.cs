using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class VitalityFormulaFactory : AttributeFormulaFactory
    {
        public VitalityFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList, double heroLvl)
            : base(factories, mainAttributeFetcher, itemList, heroLvl, 2.0)
        {
        }
    }
}