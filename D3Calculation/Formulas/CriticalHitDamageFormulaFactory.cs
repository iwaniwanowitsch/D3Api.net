using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class CriticalHitDamageFormulaFactory : AbstractFormulaFactory
    {
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
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _critDamageFetcher);
        }
    }
}