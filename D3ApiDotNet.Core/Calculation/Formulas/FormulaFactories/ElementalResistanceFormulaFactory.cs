using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class ElementalResistanceFormulaFactory<T> : AbstractItemsFormulaFactory where T : IAttributeFetcher
    {
        private readonly T _elementalResistanceFetcher;
        private readonly AttributeFormulaFactory _intelligenceFormulaFactory;

        public ElementalResistanceFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, T elementalResistanceFetcher, AttributeFormulaFactory intelligenceFormulaFactory)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
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