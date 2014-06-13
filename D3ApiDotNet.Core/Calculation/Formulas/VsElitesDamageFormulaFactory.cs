using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VsElitesDamageFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ElitesBonusDamageFetcher _elitesBonusDamageFetcher;

        public VsElitesDamageFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ElitesBonusDamageFetcher elitesBonusDamageFetcher)
            : base(factories, itemListData)
        {
            if (elitesBonusDamageFetcher == null) throw new ArgumentNullException("elitesBonusDamageFetcher");
            _elitesBonusDamageFetcher = elitesBonusDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemListData, _elitesBonusDamageFetcher);
        }
    }
}