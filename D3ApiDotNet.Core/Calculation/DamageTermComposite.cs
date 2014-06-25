using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation
{
    public class DamageTermComposite : ITerm
    {
        private int? _heroLvl;
        private IAttributeFetcher _mainStatFetcher;

        private readonly ElementalTermFactories _elementalTermsFactory;

        private readonly WeaponAvgDmgFormulaFactory _weaponAvgDmgFactory;
        private readonly WeaponDmgFormulaFactory _weaponDmgFactory;
        private readonly WeaponApsFormulaFactory _weaponApsFactory;
        private readonly WeaponDpsFormulaFactory _weaponDpsFactory;
        private readonly CriticalHitDamageFormulaFactory _criticalHitDamageFactory;
        private readonly CriticalHitChanceFormulaFactory _criticalHitChanceFactory;
        private readonly BonusAtkSpdFormulaFactory _bonusAtkSpdFactory;
        private readonly MainAttributeFormulaFactory _mainStatFactory;
        private readonly DamageFormulaFactory _damageFactory;
        private readonly ElementalDamageFormulaFactory _elementalDamageFactory;
        private readonly VsElitesDamageFormulaFactory _vsElitesDamageFactory;
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
            _elementalTermsFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory, productFactory, divisionFactory), new MaxTermFactory());

            _weaponAvgDmgFactory = new WeaponAvgDmgFormulaFactory(_elementalTermsFactory, itemListData, new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher(), new PercentWeaponDamageFetcher());
            _weaponDmgFactory = new WeaponDmgFormulaFactory(_elementalTermsFactory, itemListData, _weaponAvgDmgFactory, new BonusAvgDmgFormulaFactory(_elementalTermsFactory, itemListData, new MinDamageFetcher(), new DeltaDamageFetcher()));
            _weaponApsFactory = new WeaponApsFormulaFactory(_elementalTermsFactory, itemListData, new ApsWeaponFetcher(), new ApsPercentWeaponFetcher());
            _weaponDpsFactory = new WeaponDpsFormulaFactory(_elementalTermsFactory, _weaponDmgFactory, _weaponApsFactory);

            _criticalHitDamageFactory = new CriticalHitDamageFormulaFactory(_elementalTermsFactory, itemListData, new CritDamageFetcher());
            _criticalHitChanceFactory = new CriticalHitChanceFormulaFactory(_elementalTermsFactory, itemListData, new CritPercentFetcher());
            _bonusAtkSpdFactory = new BonusAtkSpdFormulaFactory(_elementalTermsFactory, itemListData, new ApsPercentFetcher());
            _mainStatFactory = new MainAttributeFormulaFactory(_elementalTermsFactory, MainStatFetcher, itemListData, HeroLvl.Value);

            _damageFactory = new DamageFormulaFactory(_elementalTermsFactory, _weaponDpsFactory, _criticalHitDamageFactory, _criticalHitChanceFactory, _bonusAtkSpdFactory, _mainStatFactory);

            _elementalDamageFactory = new ElementalDamageFormulaFactory(_elementalTermsFactory,
                new SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher>(_elementalTermsFactory, itemListData, new PhysicalBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher>(_elementalTermsFactory, itemListData, new ColdBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<FireBonusDamageFetcher>(_elementalTermsFactory, itemListData, new FireBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher>(_elementalTermsFactory, itemListData, new LightningBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher>(_elementalTermsFactory, itemListData, new PoisonBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher>(_elementalTermsFactory, itemListData, new ArcaneBonusDamageFetcher())
            );
            _vsElitesDamageFactory = new VsElitesDamageFormulaFactory(_elementalTermsFactory, itemListData, new ElitesBonusDamageFetcher());

            _resourceCostReductionFactory = new ResourceCostReductionFormulaFactory(_elementalTermsFactory, itemListData, new ResourceCostReductionFetcher());
            _cooldownReductionFactory = new CooldownReductionFormulaFactory(_elementalTermsFactory, itemListData, new CooldownReductionFetcher());
        }

        public ITerm DamageWithElemental
        {
            get { return _elementalTermsFactory.ProductFactory.CreateFormulaTerm(_damageFactory.CreateFormula(), _elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_elementalDamageFactory.CreateFormula())); }
        }

        public ITerm DamageWithElementalAndVsElites
        {
            get { return _elementalTermsFactory.ProductFactory.CreateFormulaTerm(DamageWithElemental, _elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_vsElitesDamageFactory.CreateFormula())); }
        }

        public ITerm AttacksPerSecond
        {
            get { return _elementalTermsFactory.ProductFactory.CreateFormulaTerm(_weaponApsFactory.CreateFormula(), _elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_bonusAtkSpdFactory.CreateFormula())); }
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
