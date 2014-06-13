using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class SingleElementalDamageFormulaFactory<T> : AbstractItemsFormulaFactory where T : IAttributeFetcher
    {
        private readonly T _elementalDamageFetcher;

        public SingleElementalDamageFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, T elementalDamageFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            _elementalDamageFetcher = elementalDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(ItemListData, _elementalDamageFetcher);
        }
    }
}