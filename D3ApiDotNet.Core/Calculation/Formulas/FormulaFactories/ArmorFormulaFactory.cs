using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class ArmorFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly AttributeFormulaFactory _strengthFormulaFactory;
        private readonly ArmorFetcher _armorFetcher;

        public ArmorFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, AttributeFormulaFactory strengthFormulaFactory, ArmorFetcher armorFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (strengthFormulaFactory == null) throw new ArgumentNullException("strengthFormulaFactory");
            if (armorFetcher == null) throw new ArgumentNullException("armorFetcher");
            _strengthFormulaFactory = strengthFormulaFactory;
            _armorFetcher = armorFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(ItemListData, _armorFetcher),
                _strengthFormulaFactory.CreateFormula());
        }
    }
}