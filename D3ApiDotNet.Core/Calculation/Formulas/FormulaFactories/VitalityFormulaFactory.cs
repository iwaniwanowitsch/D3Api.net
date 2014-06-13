using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class VitalityFormulaFactory : AttributeFormulaFactory
    {
        public VitalityFormulaFactory(ElementalTermFactories factories, IAttributeFetcher vitalityFetcher, IItemListDataContainer itemListData, double heroLvl)
            : base(factories, vitalityFetcher, itemListData, heroLvl, 2.0)
        {
        }
    }
}