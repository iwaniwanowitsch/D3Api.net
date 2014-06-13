using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class MaxLifeFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly HpPercentFetcher _hpPercentFetcher;
        private readonly VitalityFormulaFactory _vitalityFormula;
        private readonly double _heroLvl;

        public MaxLifeFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, HpPercentFetcher hpPercentFetcher, VitalityFormulaFactory vitalityFormula, double heroLvl)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (hpPercentFetcher == null) throw new ArgumentNullException("hpPercentFetcher");
            if (vitalityFormula == null) throw new ArgumentNullException("vitalityFormula");
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
                Factories.PercentSumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateAttributeTerm(ItemListData, _hpPercentFetcher)));
        }
    }
}