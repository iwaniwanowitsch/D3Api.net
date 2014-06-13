using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class VsElitesDamageFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ElitesBonusDamageFetcher _elitesBonusDamageFetcher;

        public VsElitesDamageFormulaFactory(ElementalTermFactories factories, EventHandler<IList<Item>> itemsChangedHandler, ElitesBonusDamageFetcher elitesBonusDamageFetcher)
            : base(factories, itemsChangedHandler)
        {
            if (elitesBonusDamageFetcher == null) throw new ArgumentNullException("elitesBonusDamageFetcher");
            _elitesBonusDamageFetcher = elitesBonusDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemsChangedHandler, _elitesBonusDamageFetcher);
        }
    }
}