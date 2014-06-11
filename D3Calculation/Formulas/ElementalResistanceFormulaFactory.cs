using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class ElementalResistanceFormulaFactory<T> : AbstractFormulaFactory where T : IAttributeFetcher
    {
        private readonly IList<Item> _itemList;
        private readonly T _elementalResistanceFetcher;
        private readonly AttributeFormulaFactory _intelligenceFormulaFactory;

        public ElementalResistanceFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, T elementalResistanceFetcher, AttributeFormulaFactory intelligenceFormulaFactory) : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (elementalResistanceFetcher == null) throw new ArgumentNullException("elementalResistanceFetcher");
            if (intelligenceFormulaFactory == null) throw new ArgumentNullException("intelligenceFormulaFactory");
            _itemList = itemList;
            _elementalResistanceFetcher = elementalResistanceFetcher;
            _intelligenceFormulaFactory = intelligenceFormulaFactory;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.SumFactory.CreateFormulaTerm(
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _elementalResistanceFetcher),
                    Factories.ProductFactory.CreateFormulaTerm(_intelligenceFormulaFactory.CreateFormula(),
                        Factories.BaseFactory.CreateConstantTerm(1.0/10)));
        }
    }
}