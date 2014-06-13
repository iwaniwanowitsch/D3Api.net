using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class VsElitesDamageFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly ElitesBonusDamageFetcher _elitesBonusDamageFetcher;

        public VsElitesDamageFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, ElitesBonusDamageFetcher elitesBonusDamageFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (elitesBonusDamageFetcher == null) throw new ArgumentNullException("elitesBonusDamageFetcher");
            _elitesBonusDamageFetcher = elitesBonusDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemListData, _elitesBonusDamageFetcher);
        }
    }
}