using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class CriticalHitChanceFormulaFactory : AbstractItemsFormulaFactory
    {
        private const double CcPercentDefaultConst = 0.05;
        private readonly CritPercentFetcher _critPercentFetcher;

        public CriticalHitChanceFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, CritPercentFetcher critPercentFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (critPercentFetcher == null) throw new ArgumentNullException("critPercentFetcher");
            _critPercentFetcher = critPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(CcPercentDefaultConst),Factories.BaseFactory.CreateAttributeTerm(ItemListData, _critPercentFetcher));
        }
    }
}