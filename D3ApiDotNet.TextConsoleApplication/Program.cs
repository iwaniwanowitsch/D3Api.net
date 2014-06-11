using System;
using System.Collections.Generic;
using System.Linq;
using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.ItemFetchers;

namespace D3ApiDotNet.TextConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConfigureContainer;
            //var damageCalculator = container.Resolve<IDamageCalculator>();
            do
            {
                Console.Clear();
                //var battletag = "iwaniwanow#2854";
                Console.SetCursorPosition(0, 0);
                Console.Write("Enter Battletag: ");
                var battletag = Console.ReadLine();

                var d3api = new ApiAccessFacade(CollectMode.TryCacheThenOnline, Locales.en_GB, null/*new System.Net.WebProxy("127.0.0.1:3128")*/);

                var myprofile = d3api.ProfileRepository.GetByBattletag(battletag);
                if (myprofile.IsErrorObject())
                {
                    Console.WriteLine("Invalid battletag. Press key to try again");
                    continue;
                }

                Console.WriteLine("Profile: {0}", battletag);
                for (var i = 0; i < myprofile.Heroes.Length; i++)
                {
                    Console.WriteLine("({0}) {1}", i, myprofile.Heroes[i].Name);
                }
                Console.WriteLine("({0}) {1}", myprofile.Heroes.Length, "Exit");
                int heroid;
                try
                {
                    var key = Console.ReadKey(true).KeyChar - '0';
                    if (key == myprofile.Heroes.Length)
                        return;
                    heroid = key;
                }
                catch (FormatException)
                {
                    continue;
                }
                Console.Clear();

                var myhero = d3api.HeroRepository.GetByBattletagAndId(battletag, myprofile.Heroes[heroid].Id.ToString());

                // hero items list
                var itemListFetcher = new HeroItemsFetcher(d3api.ItemRepository);
                var itemList = itemListFetcher.GetItemsList(myhero);
                var weaponList = itemList.Where(o => o.AttacksPerSecond != null).ToList();

                var heroMainStatFetcherLookup = new Dictionary<HeroClass, IAttributeFetcher>
                {
                    {HeroClass.Barbarian, new StrengthFetcher()},
                    {HeroClass.Crusader, new StrengthFetcher()},
                    {HeroClass.Demonhunter, new DexterityFetcher()},
                    {HeroClass.Monk, new DexterityFetcher()},
                    {HeroClass.Witchdoctor, new IntelligenceFetcher()},
                    {HeroClass.Wizard, new IntelligenceFetcher()}
                };

                var mainStatFetcher = heroMainStatFetcherLookup[myhero.HeroClass];

                var sumFactory = new SumTermFactory();
                var productFactory = new ProductTermFactory();
                var divisionFactory = new DivisionTermFactory();
                var elementalTermsFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory, productFactory, divisionFactory), new MaxTermFactory());

                var weaponAvgDmgFactory = new WeaponAvgDmgFormulaFactory(elementalTermsFactory, weaponList, new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher());
                var weaponDmgFactory = new WeaponDmgFormulaFactory(elementalTermsFactory, weaponList, new PercentWeaponDamageFetcher(), weaponAvgDmgFactory, new BonusAvgDmgFormulaFactory(elementalTermsFactory, itemList, new MinDamageFetcher(), new DeltaDamageFetcher()));
                var weaponApsFactory = new WeaponApsFormulaFactory(elementalTermsFactory, weaponList, new ApsWeaponFetcher(), new ApsPercentWeaponFetcher());
                var weaponDpsFactory = new WeaponDpsFormulaFactory(elementalTermsFactory, weaponDmgFactory, weaponApsFactory);

                var criticalHitDamageFactory = new CriticalHitDamageFormulaFactory(elementalTermsFactory, itemList, new CritDamageFetcher());
                var criticalHitChanceFactory = new CriticalHitChanceFormulaFactory(elementalTermsFactory, itemList, new CritPercentFetcher());
                var bonusAtkSpdFactory = new BonusAtkSpdFormulaFactory(elementalTermsFactory, itemList, new ApsPercentFetcher());
                var mainStatFactory = new MainAttributeFormulaFactory(elementalTermsFactory, mainStatFetcher, itemList, myhero.Level);

                var damageFactory = new DamageFormulaFactory(elementalTermsFactory, weaponDpsFactory, criticalHitDamageFactory, criticalHitChanceFactory, bonusAtkSpdFactory, mainStatFactory);

                var attacksPerSecond = elementalTermsFactory.ProductFactory.CreateFormulaTerm(weaponApsFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(bonusAtkSpdFactory.CreateFormula()));

                var elementalDamageFactory = new ElementalDamageFormulaFactory(elementalTermsFactory,
                    new SingleElementalDamageFormulaFactory<PhysicalBonusDamageFetcher>(elementalTermsFactory, itemList, new PhysicalBonusDamageFetcher()),
                    new SingleElementalDamageFormulaFactory<ColdBonusDamageFetcher>(elementalTermsFactory, itemList, new ColdBonusDamageFetcher()),
                    new SingleElementalDamageFormulaFactory<FireBonusDamageFetcher>(elementalTermsFactory, itemList, new FireBonusDamageFetcher()),
                    new SingleElementalDamageFormulaFactory<LightningBonusDamageFetcher>(elementalTermsFactory, itemList, new LightningBonusDamageFetcher()),
                    new SingleElementalDamageFormulaFactory<PoisonBonusDamageFetcher>(elementalTermsFactory, itemList, new PoisonBonusDamageFetcher()),
                    new SingleElementalDamageFormulaFactory<ArcaneBonusDamageFetcher>(elementalTermsFactory, itemList, new ArcaneBonusDamageFetcher())
                );
                var vsElitesDamageFactory = new VsElitesDamageFormulaFactory(elementalTermsFactory, itemList, new ElitesBonusDamageFetcher());

                var damageWithElemental = elementalTermsFactory.ProductFactory.CreateFormulaTerm(damageFactory.CreateFormula(), elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(elementalDamageFactory.CreateFormula()));
                var damageWithElementalAndVsElites = elementalTermsFactory.ProductFactory.CreateFormulaTerm(damageWithElemental, elementalTermsFactory.PercentSumFactory.CreateFormulaTerm(vsElitesDamageFactory.CreateFormula()));

                var resourceCostReductionFactory = new ResourceCostReductionFormulaFactory(elementalTermsFactory, itemList, new ResourceCostReductionFetcher());
                var cooldownReductionFactory = new CooldownReductionFormulaFactory(elementalTermsFactory, itemList, new CooldownReductionFetcher());
                //var container = new ServiceContainer();
                //var damageFactory = container.GetInstance<DamageFormulaFactory>();

                var ehpCalculator = new EhpCalculator(itemList, myhero.HeroClass);

                var ehp = ehpCalculator.GetEhp(myhero.Level);

                Console.WriteLine(myhero.Name);
                Console.WriteLine("Profile Damage: {0:0.##}", myhero.Stats.Damage);
                Console.WriteLine("Corrected Damage (with Set boni): {0:0.##}", damageFactory.CreateFormula().Evaluate());
                Console.WriteLine("{0} Elemental Bonus Damage: {1:0.##}%", elementalDamageFactory.MaxElementToString(), elementalDamageFactory.CreateFormula().Evaluate() * 100);
                Console.WriteLine("Elemental Damage: {0:0.##}", damageWithElemental.Evaluate());
                Console.WriteLine("Damage vs Elites Bonus: {0:0.##}%", vsElitesDamageFactory.CreateFormula().Evaluate() * 100);
                Console.WriteLine("vs Elites Bonus Damage: {0:0.##}", damageWithElementalAndVsElites.Evaluate());
                Console.WriteLine("Cooldown Reduction: {0:0.##}%", cooldownReductionFactory.CreateFormula().Evaluate());
                Console.WriteLine("Resource Cost Reduction: {0:0.##}%", resourceCostReductionFactory.CreateFormula().Evaluate() * 100);
                Console.WriteLine("Main Stats: {0:0.##}", mainStatFactory.CreateFormula().Evaluate());
                Console.WriteLine("Critical Hit Damage: {0:0.##}%", criticalHitDamageFactory.CreateFormula().Evaluate());
                Console.WriteLine("Critical Hit Chance: {0:0.##}%", criticalHitChanceFactory.CreateFormula().Evaluate());
                Console.WriteLine("Attacks per second: {0:0.##}", attacksPerSecond.Evaluate());
                Console.WriteLine("eHp: {0:0.##}", ehp);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
