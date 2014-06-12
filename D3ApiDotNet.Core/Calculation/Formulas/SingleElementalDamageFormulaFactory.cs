using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class SingleElementalDamageFormulaFactory<T> : AbstractFormulaFactory where T : IAttributeFetcher
    {
        private readonly IList<Item> _itemList;
        private readonly T _elementalDamageFetcher;

        public SingleElementalDamageFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, T elementalDamageFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (elementalDamageFetcher == null) throw new ArgumentNullException("elementalDamageFetcher");
            _itemList = itemList;
            _elementalDamageFetcher = elementalDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _elementalDamageFetcher);
        }
    }
}