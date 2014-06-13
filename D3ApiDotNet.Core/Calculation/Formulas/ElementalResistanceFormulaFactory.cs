using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ElementalResistanceFormulaFactory<T> : AbstractItemsFormulaFactory where T : IAttributeFetcher
    {
        private readonly T _elementalResistanceFetcher;
        private readonly AttributeFormulaFactory _intelligenceFormulaFactory;

        public ElementalResistanceFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, T elementalResistanceFetcher, AttributeFormulaFactory intelligenceFormulaFactory)
            : base(factories, itemListData)
        {
            if (elementalResistanceFetcher == null) throw new ArgumentNullException("elementalResistanceFetcher");
            if (intelligenceFormulaFactory == null) throw new ArgumentNullException("intelligenceFormulaFactory");
            _elementalResistanceFetcher = elementalResistanceFetcher;
            _intelligenceFormulaFactory = intelligenceFormulaFactory;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.SumFactory.CreateFormulaTerm(
                    Factories.BaseFactory.CreateAttributeTerm(ItemListData, _elementalResistanceFetcher),
                    Factories.ProductFactory.CreateFormulaTerm(_intelligenceFormulaFactory.CreateFormula(),
                        Factories.BaseFactory.CreateConstantTerm(1.0/10)));
        }
    }
}