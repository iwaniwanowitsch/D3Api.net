using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation
{
    public class DamageTermComposite : ITerm
    {
        private int? _heroLvl;
        private IAttributeFetcher _mainStatFetcher;

        private readonly WeaponAvgDmgFormulaFactory _weaponAvgDmgFactory;
        private readonly WeaponDmgFormulaFactory _weaponDmgFactory;
        private readonly WeaponApsFormulaFactory _weaponApsFactory;
        private readonly WeaponDpsFormulaFactory _weaponDpsFactory;
        private readonly CriticalHitDamageFormulaFactory _criticalHitDamageFactory;
        private readonly CriticalHitChanceFormulaFactory _criticalHitChanceFactory;
        private readonly BonusAtkSpdFormulaFactory _bonusAtkSpdFactory;
        private readonly MainAttributeFormulaFactory _mainStatFactory;
        private readonly DamageFormulaFactory _damageFactory;
        private readonly ITerm _attacksPerSecond;
        private readonly ElementalDamageFormulaFactory _elementalDamageFactory;
        private readonly VsElitesDamageFormulaFactory _vsElitesDamageFactory;
        private readonly ITerm _damageWithElemental;
        private readonly ITerm _damageWithElementalAndVsElites;
        private readonly ResourceCostReductionFormulaFactory _resourceCostReductionFactory;
        private readonly CooldownReductionFormulaFactory _cooldownReductionFactory;

        public DamageTermComposite(int? heroLvl, IAttributeFetcher mainStatFetcher, IItemListDataContainer itemListData)
        {
            if (heroLvl == null) throw new ArgumentNullException("heroLvl");
            if (mainStatFetcher == null) throw new ArgumentNullException("mainStatFetcher");
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            HeroLvl = heroLvl;
            MainStatFetcher = mainStatFetcher;

            var sumFactory = new SumTermFactory();
            var productFactory = new ProductTermFactory();
            var divisionFactory = new DivisionTermFactory();
            var elementalTermsFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory, productFactory, divisionFactory), new MaxTermFactory());

            _weaponAvgDmgFactory = new WeaponAvgDmgFormulaFactory(elementalTermsFactory, itemListData, new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher());
            _weaponDmgFactory = new WeaponDmgFormulaFactory(elementalTermsFactory, itemListData, new PercentWeaponDamageFetcher(), _weaponAvgDmgFactory, new BonusAvgDmgFormulaFactory(elementalTermsFactory, itemListData, new MinDamageFetcher(), new DeltaDamageFetcher()));
            _weaponApsFactory = new WeaponApsFormulaFactory(elementalTermsFactory, itemListData, new ApsWeaponFetcher(), new ApsPercentWeaponFetcher());
            _weaponDpsFactory = new WeaponDpsFormulaFactory(elementalTermsFactory, _weaponDmgFactory, _weaponApsFactory);

            _criticalHitDamageFactory = new CriticalHitDamageFormulaFactory(elementalTermsFactory, itemListData, new CritDamageFetcher());
            _criticalHitChanceFactory = new CriticalHitChanceFormulaFactory(elementalTermsFactory, itemListData, new CritPercentFetcher());
            _bonusAtkSpdFactory = new BonusAtkSpdFormulaFactory(elementalTermsFactory, itemListData, new ApsPercentFetcher());
            _mainStatFactory = new MainAttributeFormulaFactory(elementalTermsFactory, MainStatFetcher, itemListData, HeroLvl.Value);

            _damageFactory = new DamageFormulaFactory(elementalTermsFactory, _weaponDpsFactory, _criticalHitDamageFactory, _criticalHitChanceFactory, _bonusAtkSpdFactory, _mainStatFactory);

            _attacksPerSecond = elementalTermsFactory.ProductFactory.CreateFormulaTerm(_weaponApsFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_bonusAtkSpdFactory.CreateFormula()));

            _elementalDamageFactory = new ElementalDamageFormulaFactory(elementalTermsFactory,
                new SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher>(elementalTermsFactory, itemListData, new PhysicalBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher>(elementalTermsFactory, itemListData, new ColdBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<FireBonusDamageFetcher>(elementalTermsFactory, itemListData, new FireBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher>(elementalTermsFactory, itemListData, new LightningBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher>(elementalTermsFactory, itemListData, new PoisonBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher>(elementalTermsFactory, itemListData, new ArcaneBonusDamageFetcher())
            );
            _vsElitesDamageFactory = new VsElitesDamageFormulaFactory(elementalTermsFactory, itemListData, new ElitesBonusDamageFetcher());

            _damageWithElemental = elementalTermsFactory.ProductFactory.CreateFormulaTerm(_damageFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_elementalDamageFactory.CreateFormula()));
            _damageWithElementalAndVsElites = elementalTermsFactory.ProductFactory.CreateFormulaTerm(DamageWithElemental, elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_vsElitesDamageFactory.CreateFormula()));

            _resourceCostReductionFactory = new ResourceCostReductionFormulaFactory(elementalTermsFactory, itemListData, new ResourceCostReductionFetcher());
            _cooldownReductionFactory = new CooldownReductionFormulaFactory(elementalTermsFactory, itemListData, new CooldownReductionFetcher());
        }

        public ITerm DamageWithElemental
        {
            get { return _damageWithElemental; }
        }

        public ITerm DamageWithElementalAndVsElites
        {
            get { return _damageWithElementalAndVsElites; }
        }

        public ITerm AttacksPerSecond
        {
            get { return _attacksPerSecond; }
        }

        public ITerm WeaponAvgDmgTerm
        {
            get { return _weaponAvgDmgFactory.CreateFormula(); }
        }

        public ITerm WeaponDmgTerm
        {
            get { return _weaponDmgFactory.CreateFormula(); }
        }

        public ITerm WeaponApsTerm
        {
            get { return _weaponApsFactory.CreateFormula(); }
        }

        public ITerm WeaponDpsTerm
        {
            get { return _weaponDpsFactory.CreateFormula(); }
        }

        public ITerm CriticalHitDamageTerm
        {
            get { return _criticalHitDamageFactory.CreateFormula(); }
        }

        public ITerm CriticalHitChanceTerm
        {
            get { return _criticalHitChanceFactory.CreateFormula(); }
        }

        public ITerm BonusAtkSpdTerm
        {
            get { return _bonusAtkSpdFactory.CreateFormula(); }
        }

        public ITerm MainStatTerm
        {
            get { return _mainStatFactory.CreateFormula(); }
        }

        public ITerm DamageTerm
        {
            get { return _damageFactory.CreateFormula(); }
        }

        public ElementalDamageFormulaFactory ElementalDamageFactory
        {
            get { return _elementalDamageFactory; }
        }

        public ITerm VsElitesDamageTerm
        {
            get { return _vsElitesDamageFactory.CreateFormula(); }
        }

        public ITerm ResourceCostReductionTerm
        {
            get { return _resourceCostReductionFactory.CreateFormula(); }
        }

        public ITerm CooldownReductionTerm
        {
            get { return _cooldownReductionFactory.CreateFormula(); }
        }

        public IAttributeFetcher MainStatFetcher
        {
            get { return _mainStatFetcher; }
            set { if (value != null) _mainStatFetcher = value; }
        }

        private int? HeroLvl
        {
            get { return _heroLvl; }
            set { _heroLvl = value; }
        }

        public double Evaluate()
        {
            return DamageTerm.Evaluate();
        }
    }
}
