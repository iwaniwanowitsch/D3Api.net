using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation
{
    public class EhpTermComposite : ITerm
    {
        private readonly int? _heroLvl;
        private readonly IItemListDataContainer _itemListData;
        private readonly OtherDamageReductionFormulaFactory _otherDamageReductionFactory;
        private readonly AttributeFormulaFactory _dexterityFactory;
        private readonly DodgeDamageReductionFormulaFactory _dodgeDamageReductionFactory;
        private readonly AttributeFormulaFactory _intelligenceFactory;
        private readonly ResistanceFormulaFactory _resistanceFactory;
        private readonly ResistanceDamageReductionFormulaFactory _resistanceDamageReductionFactory;
        private readonly AttributeFormulaFactory _strengthFactory;
        private readonly ArmorFormulaFactory _armorFactory;
        private readonly ArmorDamageReductionFormulaFactory _armorDamageReductionFactory;
        private readonly VitalityFormulaFactory _vitalityFactory;
        private readonly MaxLifeFormulaFactory _maxLifeFactory;
        private readonly EhpFormulaFactory _ehpFactory;

        public EhpTermComposite(int? heroLvl, IItemListDataContainer itemListData, HeroClass heroClass)
        {
            if (heroLvl == null) throw new ArgumentNullException("heroLvl");
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            _heroLvl = heroLvl;
            _itemListData = itemListData;

            var sumFactory = new SumTermFactory();
            var productFactory = new ProductTermFactory();
            var divisionFactory = new DivisionTermFactory();
            var elementalTermsFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory, productFactory, divisionFactory), new MaxTermFactory());

            _otherDamageReductionFactory = new OtherDamageReductionFormulaFactory(elementalTermsFactory, _itemListData,
                new MeleeDamageReductionFetcher(), new RangedDamageReductionFetcher(),
                new ElitesDamageReductionFetcher());

            _dexterityFactory = new AttributeFormulaFactory(elementalTermsFactory, new DexterityFetcher(), _itemListData,
                _heroLvl.Value, heroClass == HeroClass.Monk || heroClass == HeroClass.Demonhunter ? 3.0 : 1.0);
            _dodgeDamageReductionFactory = new DodgeDamageReductionFormulaFactory(elementalTermsFactory,
                _dexterityFactory, _heroLvl.Value);

            _intelligenceFactory = new AttributeFormulaFactory(elementalTermsFactory, new IntelligenceFetcher(),
                _itemListData, _heroLvl.Value,
                heroClass == HeroClass.Wizard || heroClass == HeroClass.Witchdoctor ? 3.0 : 1.0);
            _resistanceFactory = new ResistanceFormulaFactory(elementalTermsFactory,
                new ElementalResistanceFormulaFactory<PhysicalResistFetcher>(elementalTermsFactory, _itemListData,
                    new PhysicalResistFetcher(), _intelligenceFactory),
                new ElementalResistanceFormulaFactory<ColdResistFetcher>(elementalTermsFactory, _itemListData,
                    new ColdResistFetcher(), _intelligenceFactory),
                new ElementalResistanceFormulaFactory<FireResistFetcher>(elementalTermsFactory, _itemListData,
                    new FireResistFetcher(), _intelligenceFactory),
                new ElementalResistanceFormulaFactory<LightningResistFetcher>(elementalTermsFactory, _itemListData,
                    new LightningResistFetcher(), _intelligenceFactory),
                new ElementalResistanceFormulaFactory<PoisonResistFetcher>(elementalTermsFactory, _itemListData,
                    new PoisonResistFetcher(), _intelligenceFactory),
                new ElementalResistanceFormulaFactory<ArcaneResistFetcher>(elementalTermsFactory, _itemListData,
                    new ArcaneResistFetcher(), _intelligenceFactory));
            _resistanceDamageReductionFactory = new ResistanceDamageReductionFormulaFactory(elementalTermsFactory,
                _resistanceFactory, _heroLvl.Value);

            _strengthFactory = new AttributeFormulaFactory(elementalTermsFactory, new StrengthFetcher(), _itemListData,
                _heroLvl.Value, heroClass == HeroClass.Barbarian || heroClass == HeroClass.Crusader ? 3.0 : 1.0);
            _armorFactory = new ArmorFormulaFactory(elementalTermsFactory, _itemListData, _strengthFactory,
                new ArmorFetcher());
            _armorDamageReductionFactory = new ArmorDamageReductionFormulaFactory(elementalTermsFactory, _armorFactory,
                _heroLvl.Value);

            _vitalityFactory = new VitalityFormulaFactory(elementalTermsFactory, new VitalityFetcher(), _itemListData,
                _heroLvl.Value);
            _maxLifeFactory = new MaxLifeFormulaFactory(elementalTermsFactory, _itemListData, new HpPercentFetcher(),
                _vitalityFactory, _heroLvl.Value);
            _ehpFactory = new EhpFormulaFactory(elementalTermsFactory, _maxLifeFactory, _armorDamageReductionFactory, _resistanceDamageReductionFactory, _dodgeDamageReductionFactory, _otherDamageReductionFactory);
        }

        public ITerm OtherDamageReductionTerm
        {
            get { return _otherDamageReductionFactory.CreateFormula(); }
        }

        public ITerm DexterityTerm
        {
            get { return _dexterityFactory.CreateFormula(); }
        }

        public ITerm DodgeDamageReductionTerm
        {
            get { return _dodgeDamageReductionFactory.CreateFormula(); }
        }

        public ITerm IntelligenceTerm
        {
            get { return _intelligenceFactory.CreateFormula(); }
        }

        public ITerm ResistanceTerm
        {
            get { return _resistanceFactory.CreateFormula(); }
        }

        public ITerm ResistanceDamageReductionTerm
        {
            get { return _resistanceDamageReductionFactory.CreateFormula(); }
        }

        public ITerm StrengthTerm
        {
            get { return _strengthFactory.CreateFormula(); }
        }

        public ITerm ArmorTerm
        {
            get { return _armorFactory.CreateFormula(); }
        }

        public ITerm ArmorDamageReductionTerm
        {
            get { return _armorDamageReductionFactory.CreateFormula(); }
        }

        public ITerm VitalityTerm
        {
            get { return _vitalityFactory.CreateFormula(); }
        }

        public ITerm MaxLifeTerm
        {
            get { return _maxLifeFactory.CreateFormula(); }
        }

        public ITerm EhpTerm
        {
            get { return _ehpFactory.CreateFormula(); }
        }

        public double Evaluate()
        {
            return _ehpFactory.CreateFormula().Evaluate();
        }
    }
}