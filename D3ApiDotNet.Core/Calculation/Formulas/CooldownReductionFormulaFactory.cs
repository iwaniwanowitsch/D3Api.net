using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class CooldownReductionFormulaFactory : AbstractFormulaFactory
    {
        private readonly IList<Item> _itemList;
        private readonly CooldownReductionFetcher _cooldownReductionFetcher;

        public CooldownReductionFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, CooldownReductionFetcher cooldownReductionFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (cooldownReductionFetcher == null) throw new ArgumentNullException("cooldownReductionFetcher");
            _itemList = itemList;
            _cooldownReductionFetcher = cooldownReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1), Factories.SubstractionFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(_cooldownReductionFetcher.GetBonusDamage(_itemList)*_cooldownReductionFetcher.GetBonusDamage(_itemList.GetSetAttributes()))));
        }
    }
}