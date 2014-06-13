using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{
    public class CooldownReductionFormulaFactory : AbstractItemsFormulaFactory
    {
        private readonly CooldownReductionFetcher _cooldownReductionFetcher;

        public CooldownReductionFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData, CooldownReductionFetcher cooldownReductionFetcher)
            : base(factories, itemListData)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (cooldownReductionFetcher == null) throw new ArgumentNullException("cooldownReductionFetcher");
            _cooldownReductionFetcher = cooldownReductionFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.SumFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(1), Factories.SubstractionFactory.CreateFormulaTerm(Factories.BaseFactory.CreateConstantTerm(_cooldownReductionFetcher.GetBonusDamage(ItemList)*_cooldownReductionFetcher.GetBonusDamage(ItemList.GetSetAttributes()))));
        }
    }
}