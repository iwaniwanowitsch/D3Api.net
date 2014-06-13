using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class CriticalHitDamageFormulaFactory : AbstractItemsFormulaFactory
    {
        private const double CdPercentDefaultConst = 0.5;
        private readonly CritDamageFetcher _critDamageFetcher;

        public CriticalHitDamageFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, CritDamageFetcher critDamageFetcher)
            : base(factories, itemListData)
        {
            if (critDamageFetcher == null) throw new ArgumentNullException("critDamageFetcher");
            _critDamageFetcher = critDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(CdPercentDefaultConst), Factories.BaseFactory.CreateAttributeTerm(ItemListData, _critDamageFetcher));
        }
    }
}