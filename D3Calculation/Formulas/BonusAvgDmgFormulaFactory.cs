using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class BonusAvgDmgFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly MinDamageFetcher _minDamageFetcher;
        private readonly DeltaDamageFetcher _deltaDamageFetcher;

        public BonusAvgDmgFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, MinDamageFetcher minDamageFetcher, DeltaDamageFetcher deltaDamageFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (minDamageFetcher == null) throw new ArgumentNullException("minDamageFetcher");
            if (deltaDamageFetcher == null) throw new ArgumentNullException("deltaDamageFetcher");
            _itemList = itemList;
            _minDamageFetcher = minDamageFetcher;
            _deltaDamageFetcher = deltaDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.AverageFactory.CreateFormulaTerm(
                    Factories.SumFactory.CreateFormulaTerm(
                        Factories.BaseFactory.CreateAttributeTerm(_itemList, _minDamageFetcher),
                        Factories.BaseFactory.CreateAttributeTerm(_itemList, _minDamageFetcher)),
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _deltaDamageFetcher));

        }
    }
}