using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class ArmorFormulaFactory : AbstractFormulaFactory
    {
        private readonly AttributeFormulaFactory _strengthFormulaFactory;
        private readonly ArmorFetcher _armorFetcher;
        private readonly IList<Item> _itemList;

        public ArmorFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, AttributeFormulaFactory strengthFormulaFactory, ArmorFetcher armorFetcher)
            : base(factories)
        {
            if (strengthFormulaFactory == null) throw new ArgumentNullException("strengthFormulaFactory");
            if (armorFetcher == null) throw new ArgumentNullException("armorFetcher");
            if (itemList == null) throw new ArgumentNullException("itemList");
            _strengthFormulaFactory = strengthFormulaFactory;
            _armorFetcher = armorFetcher;
            _itemList = itemList;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(_itemList, _armorFetcher),
                _strengthFormulaFactory.CreateFormula());
        }
    }
}