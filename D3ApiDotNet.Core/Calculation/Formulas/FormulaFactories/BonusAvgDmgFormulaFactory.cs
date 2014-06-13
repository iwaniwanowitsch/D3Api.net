using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class BonusAvgDmgFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly MinDamageFetcher _minDamageFetcher;
        private readonly DeltaDamageFetcher _deltaDamageFetcher;

        public BonusAvgDmgFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, MinDamageFetcher minDamageFetcher, DeltaDamageFetcher deltaDamageFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (minDamageFetcher == null) throw new ArgumentNullException("minDamageFetcher");
            if (deltaDamageFetcher == null) throw new ArgumentNullException("deltaDamageFetcher");
            _minDamageFetcher = minDamageFetcher;
            _deltaDamageFetcher = deltaDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.AverageFactory.CreateFormulaTerm(
                    Factories.SumFactory.CreateFormulaTerm(
                        Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minDamageFetcher),
                        Factories.BaseFactory.CreateAttributeTerm(ItemListData, _minDamageFetcher)),
                    Factories.BaseFactory.CreateAttributeTerm(ItemListData, _deltaDamageFetcher));

        }
    }
}