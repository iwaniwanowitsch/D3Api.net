using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class AttributeFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly IAttributeFetcher _attributeFetcher;
        private readonly double _heroLvl;
        private readonly double _attributePerLevel;
        private const double StatsDefaultConst = 7.0;

        public AttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher attributeFetcher, IItemListDataContainer itemListData, double heroLvl, double attributePerLevel)
            : base(factories, itemListData)
        {
            if (attributeFetcher == null) throw new ArgumentNullException("attributeFetcher");
            _attributeFetcher = attributeFetcher;
            _heroLvl = heroLvl;
            _attributePerLevel = attributePerLevel;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(StatsDefaultConst), Factories.BaseFactory.CreateAttributeTerm(ItemListData, _attributeFetcher), Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(_attributePerLevel), Factories.BaseFactory.CreateConstantTerm(_heroLvl)));
        }
    }
}