using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class CriticalHitChanceFormulaFactory : AbstractFormulaFactory
    {
        private const double CcPercentDefaultConst = 0.05;
        private readonly IList<Item> _itemList;
        private readonly CritPercentFetcher _critPercentFetcher;

        public CriticalHitChanceFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, CritPercentFetcher critPercentFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (critPercentFetcher == null) throw new ArgumentNullException("critPercentFetcher");
            _itemList = itemList;
            _critPercentFetcher = critPercentFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(CcPercentDefaultConst),Factories.BaseFactory.CreateAttributeTerm(_itemList, _critPercentFetcher));
        }
    }
}