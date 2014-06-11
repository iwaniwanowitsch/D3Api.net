using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public class OtherDamageReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly MeleeDamageReductionFetcher _meleeDamageReductionFetcher;
        private readonly RangedDamageReductionFetcher _rangedDamageReductionFetcher;
        private readonly ElitesDamageReductionFetcher _elitesDamageReductionFetcher;

        public OtherDamageReductionFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, MeleeDamageReductionFetcher meleeDamageReductionFetcher, RangedDamageReductionFetcher rangedDamageReductionFetcher, ElitesDamageReductionFetcher elitesDamageReductionFetcher) : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (meleeDamageReductionFetcher == null) throw new ArgumentNullException("meleeDamageReductionFetcher");
            if (rangedDamageReductionFetcher == null) throw new ArgumentNullException("rangedDamageReductionFetcher");
            if (elitesDamageReductionFetcher == null) throw new ArgumentNullException("elitesDamageReductionFetcher");
            _itemList = itemList;
            _meleeDamageReductionFetcher = meleeDamageReductionFetcher;
            _rangedDamageReductionFetcher = rangedDamageReductionFetcher;
            _elitesDamageReductionFetcher = elitesDamageReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.AverageFactory.CreateFormulaTerm(
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _meleeDamageReductionFetcher),
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _rangedDamageReductionFetcher),
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _elitesDamageReductionFetcher));
        }
    }
}