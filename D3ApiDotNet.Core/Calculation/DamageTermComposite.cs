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
        private IList<Item> _itemList;
        private IList<Item> _weaponList;

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

        public DamageTermComposite(int? heroLvl, IAttributeFetcher mainStatFetcher, IList<Item> itemList)
        {
            if (heroLvl == null) throw new ArgumentNullException("heroLvl");
            if (mainStatFetcher == null) throw new ArgumentNullException("mainStatFetcher");
            if (itemList == null) throw new ArgumentNullException("itemList");
            HeroLvl = heroLvl;
            MainStatFetcher = mainStatFetcher;
            ItemList = itemList;

            var sumFactory = new SumTermFactory();
            var productFactory = new ProductTermFactory();
            var divisionFactory = new DivisionTermFactory();
            var elementalTermsFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory, productFactory, divisionFactory), new MaxTermFactory());

            _weaponAvgDmgFactory = new WeaponAvgDmgFormulaFactory(elementalTermsFactory, _weaponList, new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher());
            _weaponDmgFactory = new WeaponDmgFormulaFactory(elementalTermsFactory, _weaponList, new PercentWeaponDamageFetcher(), _weaponAvgDmgFactory, new BonusAvgDmgFormulaFactory(elementalTermsFactory, itemList, new MinDamageFetcher(), new DeltaDamageFetcher()));
            _weaponApsFactory = new WeaponApsFormulaFactory(elementalTermsFactory, _weaponList, new ApsWeaponFetcher(), new ApsPercentWeaponFetcher());
            _weaponDpsFactory = new WeaponDpsFormulaFactory(elementalTermsFactory, _weaponDmgFactory, _weaponApsFactory);

            _criticalHitDamageFactory = new CriticalHitDamageFormulaFactory(elementalTermsFactory, _itemList, new CritDamageFetcher());
            _criticalHitChanceFactory = new CriticalHitChanceFormulaFactory(elementalTermsFactory, _itemList, new CritPercentFetcher());
            _bonusAtkSpdFactory = new BonusAtkSpdFormulaFactory(elementalTermsFactory, _itemList, new ApsPercentFetcher());
            _mainStatFactory = new MainAttributeFormulaFactory(elementalTermsFactory, MainStatFetcher, _itemList, HeroLvl.Value);

            _damageFactory = new DamageFormulaFactory(elementalTermsFactory, _weaponDpsFactory, _criticalHitDamageFactory, _criticalHitChanceFactory, _bonusAtkSpdFactory, _mainStatFactory);

            _attacksPerSecond = elementalTermsFactory.ProductFactory.CreateFormulaTerm(_weaponApsFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_bonusAtkSpdFactory.CreateFormula()));

            _elementalDamageFactory = new ElementalDamageFormulaFactory(elementalTermsFactory,
                new SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher>(elementalTermsFactory, _itemList, new PhysicalBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher>(elementalTermsFactory, _itemList, new ColdBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<FireBonusDamageFetcher>(elementalTermsFactory, _itemList, new FireBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher>(elementalTermsFactory, _itemList, new LightningBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher>(elementalTermsFactory, _itemList, new PoisonBonusDamageFetcher()),
                new SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher>(elementalTermsFactory, _itemList, new ArcaneBonusDamageFetcher())
            );
            _vsElitesDamageFactory = new VsElitesDamageFormulaFactory(elementalTermsFactory, _itemList, new ElitesBonusDamageFetcher());

            _damageWithElemental = elementalTermsFactory.ProductFactory.CreateFormulaTerm(_damageFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_elementalDamageFactory.CreateFormula()));
            _damageWithElementalAndVsElites = elementalTermsFactory.ProductFactory.CreateFormulaTerm(DamageWithElemental, elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(_vsElitesDamageFactory.CreateFormula()));

            _resourceCostReductionFactory = new ResourceCostReductionFormulaFactory(elementalTermsFactory, _itemList, new ResourceCostReductionFetcher());
            _cooldownReductionFactory = new CooldownReductionFormulaFactory(elementalTermsFactory, _itemList, new CooldownReductionFetcher());
        }

        private IList<Item> ItemList
        {
            get { return _itemList; }
            set {
                if (value == null) return;
                _itemList = value;
                _weaponList = _itemList.Where(o => o.AttacksPerSecond != null).ToList();
            }
        }

        public IList<Item> WeaponList
        {
            get { return _weaponList; }
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
