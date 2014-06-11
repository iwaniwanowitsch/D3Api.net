using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ElementalDamageFormulaFactory : AbstractFormulaFactory
    {
        private readonly Dictionary<AbstractFormulaFactory, string> _nameLookup;

        public ElementalDamageFormulaFactory(ElementalTermFactories factories, SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher> physDamageFormula, SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher> coldDamageFormula, SingleElementalDamageFormulaFactory<FireBonusDamageFetcher> fireDamageFormula, SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher> lightDamageFormula, SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher> poisonDamageFormula, SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher> arcaneDamageFormula)
            : base(factories)
        {
            if (physDamageFormula == null) throw new ArgumentNullException("physDamageFormula");
            if (coldDamageFormula == null) throw new ArgumentNullException("coldDamageFormula");
            if (fireDamageFormula == null) throw new ArgumentNullException("fireDamageFormula");
            if (lightDamageFormula == null) throw new ArgumentNullException("lightDamageFormula");
            if (poisonDamageFormula == null) throw new ArgumentNullException("poisonDamageFormula");
            if (arcaneDamageFormula == null) throw new ArgumentNullException("arcaneDamageFormula");

            _nameLookup = new Dictionary<AbstractFormulaFactory, string>
            {
                {physDamageFormula,"Physical"},
                {coldDamageFormula,"Cold"},
                {fireDamageFormula,"Fire"},
                {lightDamageFormula,"Lightnig"},
                {poisonDamageFormula,"Poison"},
                {arcaneDamageFormula,"Arcane"}
            };
        }

        public override ITerm CreateFormula()
        {
            return Factories.MaxFactory.CreateFormulaTerm(_nameLookup.Select(o => o.Key.CreateFormula()).ToArray());
        }

        public string MaxElementToString()
        {
            return _nameLookup.First(o => Math.Abs(o.Key.CreateFormula().Evaluate() - this.CreateFormula().Evaluate()) < 0.000001).Value;
        }
    }

    public class SingleElementalDamageFormulaFactory<T> : AbstractFormulaFactory where T : IAttributeFetcher
    {
        private readonly IList<Item> _itemList;
        private readonly T _elementalDamageFetcher;

        public SingleElementalDamageFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, T elementalDamageFetcher)
            : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (elementalDamageFetcher == null) throw new ArgumentNullException("elementalDamageFetcher");
            _itemList = itemList;
            _elementalDamageFetcher = elementalDamageFetcher;
        }

        public override ITerm CreateFormula()
        {
            return Factories.BaseFactory.CreateAttributeTerm(_itemList, _elementalDamageFetcher);
        }
    }

    public class ElementalResistanceFormulaFactory<T> : AbstractFormulaFactory where T : IAttributeFetcher
    {
        private readonly IList<Item> _itemList;
        private readonly T _elementalResistanceFetcher;
        private readonly AttributeFormulaFactory _intelligenceFormulaFactory;

        public ElementalResistanceFormulaFactory(ElementalTermFactories factories, IList<Item> itemList, T elementalResistanceFetcher, AttributeFormulaFactory intelligenceFormulaFactory) : base(factories)
        {
            if (itemList == null) throw new ArgumentNullException("itemList");
            if (elementalResistanceFetcher == null) throw new ArgumentNullException("elementalResistanceFetcher");
            if (intelligenceFormulaFactory == null) throw new ArgumentNullException("intelligenceFormulaFactory");
            _itemList = itemList;
            _elementalResistanceFetcher = elementalResistanceFetcher;
            _intelligenceFormulaFactory = intelligenceFormulaFactory;
        }

        public override ITerm CreateFormula()
        {
            return
                Factories.SumFactory.CreateFormulaTerm(
                    Factories.BaseFactory.CreateAttributeTerm(_itemList, _elementalResistanceFetcher),
                    Factories.ProductFactory.CreateFormulaTerm(_intelligenceFormulaFactory.CreateFormula(),
                        Factories.BaseFactory.CreateConstantTerm(1.0/10)));
        }
    }
}