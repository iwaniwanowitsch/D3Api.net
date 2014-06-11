using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class MaxLifeFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly HpPercentFetcher _hpPercentFetcher;
        private readonly VitalityFormulaFactory _vitalityFormula;
        private readonly double _heroLvl;

        public MaxLifeFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, HpPercentFetcher hpPercentFetcher, VitalityFormulaFactory vitalityFormula, double heroLvl)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (hpPercentFetcher == null) throw new ArgumentNullException("hpPercentFetcher");
            if (vitalityFormula == null) throw new ArgumentNullException("vitalityFormula");
            _itemList = itemList;
            _hpPercentFetcher = hpPercentFetcher;
            _vitalityFormula = vitalityFormula;
            _heroLvl = heroLvl;
        }

        public override ITerm CreateFormula()
        {
            var maxlife = Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(36),
                Factories.BaseFactory.CreateConstantTerm(4*_heroLvl));
            double factor;
            if (_heroLvl < 35)
                factor = 10;
            else if (_heroLvl <= 60)
                factor = _heroLvl - 25;
            else
                factor = 80;
            maxlife = Factories.SumFactory.CreateFormulaTerm(maxlife, Factories.ProductFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(factor), _vitalityFormula.CreateFormula()));
            return Factories.ProductFactory.CreateFormulaTerm(maxlife,
                Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(_itemList, _hpPercentFetcher)));
        }
    }
}