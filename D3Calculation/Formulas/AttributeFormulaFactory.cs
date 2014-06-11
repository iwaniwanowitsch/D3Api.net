using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class AttributeFormulaFactory : AbstractFormulaFactory
    {
        private readonly IAttributeFetcher _attributeFetcher;
        private readonly IList<Item> _itemList;
        private readonly double _heroLvl;
        private readonly double _attributePerLevel;
        private const double StatsDefaultConst = 7.0;

        public AttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher attributeFetcher, IList<Item> itemList, double heroLvl, double attributePerLevel)
            : base(factories)
        {
            if (attributeFetcher == null) throw new ArgumentNullException("attributeFetcher");
            if (itemList == null) throw new ArgumentNullException("itemList");
            _attributeFetcher = attributeFetcher;
            _itemList = itemList;
            _heroLvl = heroLvl;
            _attributePerLevel = attributePerLevel;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(StatsDefaultConst), Factories.BaseFactory.CreateAttributeTerm(_itemList, _attributeFetcher), Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(_attributePerLevel), Factories.BaseFactory.CreateConstantTerm(_heroLvl)));
        }
    }
}