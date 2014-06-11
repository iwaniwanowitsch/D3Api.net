using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VsElitesDamageFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly ElitesBonusDamageFetcher _elitesBonusDamageFetcher;

        public VsElitesDamageFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, ElitesBonusDamageFetcher elitesBonusDamageFetcher) : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (elitesBonusDamageFetcher == null) throw new ArgumentNullException("elitesBonusDamageFetcher");
            _itemList = itemList;
            _elitesBonusDamageFetcher = elitesBonusDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _elitesBonusDamageFetcher);
        }
    }
}