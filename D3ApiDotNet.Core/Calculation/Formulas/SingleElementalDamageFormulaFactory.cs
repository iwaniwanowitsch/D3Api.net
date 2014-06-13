using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class SingleElementalDamageFormulaFactory<T> : AbstractItemsFormulaFactory where T : IAttributeFetcher
    {
        private readonly T _elementalDamageFetcher;

        public SingleElementalDamageFormulaFactory(ElementalTermFactories factories, EventHandler<IList<Item>> itemsChangedHandler, T elementalDamageFetcher)
            : base(factories, itemsChangedHandler)
        {
            if (elementalDamageFetcher == null) throw new ArgumentNullException("elementalDamageFetcher");
            _elementalDamageFetcher = elementalDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemsChangedHandler, _elementalDamageFetcher);
        }
    }
}