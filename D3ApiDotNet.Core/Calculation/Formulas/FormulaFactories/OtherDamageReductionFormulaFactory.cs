using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class OtherDamageReductionFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly MeleeDamageReductionFetcher _meleeDamageReductionFetcher;
        private readonly RangedDamageReductionFetcher _rangedDamageReductionFetcher;
        private readonly ElitesDamageReductionFetcher _elitesDamageReductionFetcher;

        public OtherDamageReductionFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, MeleeDamageReductionFetcher meleeDamageReductionFetcher, RangedDamageReductionFetcher rangedDamageReductionFetcher, ElitesDamageReductionFetcher elitesDamageReductionFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (meleeDamageReductionFetcher == null) throw new ArgumentNullException("meleeDamageReductionFetcher");
            if (rangedDamageReductionFetcher == null) throw new ArgumentNullException("rangedDamageReductionFetcher");
            if (elitesDamageReductionFetcher == null) throw new ArgumentNullException("elitesDamageReductionFetcher");
            _meleeDamageReductionFetcher = meleeDamageReductionFetcher;
            _rangedDamageReductionFetcher = rangedDamageReductionFetcher;
            _elitesDamageReductionFetcher = elitesDamageReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1.0),
                    Factories.SubstractionFactory.CreateFormulaTerm(
                        Factories.AverageFactory.CreateFormulaTerm(
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _meleeDamageReductionFetcher),
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _rangedDamageReductionFetcher),
                            Factories.BaseFactory.CreateAttributeTerm(ItemListData, _elitesDamageReductionFetcher))
                        ));
        }
    }
}