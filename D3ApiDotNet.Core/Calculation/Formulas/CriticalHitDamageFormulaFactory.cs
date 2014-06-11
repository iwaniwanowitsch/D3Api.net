using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class CriticalHitDamageFormulaFactory : AbstractFormulaFactory
    {
        private const double CdPercentDefaultConst = 0.5;
        private readonly IList<Item> _itemList;
        private readonly CritDamageFetcher _critDamageFetcher;

        public CriticalHitDamageFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, CritDamageFetcher critDamageFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (critDamageFetcher == null) throw new ArgumentNullException("critDamageFetcher");
            _itemList = itemList;
            _critDamageFetcher = critDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(CdPercentDefaultConst), Factories.BaseFactory.CreateAttributeTerm(_itemList, _critDamageFetcher));
        }
    }
}