using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class MainAttributeFormulaFactory : AbstractFormulaFactory
    {
        private const double MainStatsDefaultConst = 7.0;
        private const double MainStatDeltaPerLevelConst = 3.0;
        private readonly IAttributeFetcher _mainAttributeFetcher;
        private readonly IList<Item> _itemList;
        private readonly double _heroLvl;

        public MainAttributeFormulaFactory(ElementalTermFactories factories, IAttributeFetcher mainAttributeFetcher, IList<Item> itemList, double heroLvl)
            : base(factories)
        {
            if (mainAttributeFetcher == null) throw new ArgumentNullException("mainAttributeFetcher");
            if (itemList == null) throw new ArgumentNullException("itemList");
            _mainAttributeFetcher = mainAttributeFetcher;
            _itemList = itemList;
            _heroLvl = heroLvl;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(MainStatsDefaultConst), Factories.BaseFactory.CreateAttributeTerm(_itemList, _mainAttributeFetcher), Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(MainStatDeltaPerLevelConst), Factories.BaseFactory.CreateConstantTerm(_heroLvl)));
        }
    }
}