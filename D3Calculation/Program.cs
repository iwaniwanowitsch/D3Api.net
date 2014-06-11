using System;
using System.Linq;
using D3apiData;
using D3apiData.API;
using D3apiData.API.Objects.Hero;
using D3Calculation.AttributeFetchers;
using System.Collections.Generic;
using D3Calculation.Formulas;
using D3Calculation.ItemFetchers;
using LightInject;

namespace D3Calculation
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

                var d3api = new ApiAccessFacade(CollectMode.TryCacheThenOnline,Locales.en_GB);

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
                var elementalFactory = new ElementalTermFactories(new BaseTermFactory(), sumFactory, productFactory, new SubstractionTermFactory(), divisionFactory, new PercentSumTermFactory(), new AverageTermFactory(sumFactory,productFactory,divisionFactory));

                var weaponAvgDmgFactory = new WeaponAvgDmgFormulaFactory(elementalFactory, weaponList,new MinWeaponDamageFetcher(), new DeltaWeaponDamageFetcher());
                var weaponDmgFactory = new WeaponDmgFormulaFactory(elementalFactory,weaponList,new PercentWeaponDamageFetcher(), weaponAvgDmgFactory, new BonusAvgDmgFormulaFactory(elementalFactory,itemList,new MinDamageFetcher(), new DeltaDamageFetcher()));
                var weaponDpsFactory = new WeaponDpsFormulaFactory(elementalFactory,weaponDmgFactory, new WeaponApsFormulaFactory(elementalFactory,weaponList,new ApsWeaponFetcher(), new ApsPercentWeaponFetcher()));

                var damageFactory = new DamageFormulaFactory(elementalFactory, weaponDpsFactory, new CriticalHitDamageFormulaFactory(elementalFactory, itemList, new CritDamageFetcher()), new CriticalHitChanceFormulaFactory(elementalFactory, itemList, new CritPercentFetcher()), new BonusAtkSpdFormulaFactory(elementalFactory, itemList, new ApsPercentFetcher()), new MainAttributeFormulaFactory(elementalFactory, mainStatFetcher, itemList, myhero.Level));

                //var container = new ServiceContainer();
                //var damageFactory = container.GetInstance<DamageFormulaFactory>();

                Console.WriteLine(damageFactory.CreateFormula().Evaluate().ToString());
                Console.WriteLine(weaponDpsFactory.CreateFormula().ToString());
                Console.WriteLine(weaponDpsFactory.CreateFormula().Evaluate().ToString());
                Console.WriteLine((new WeaponApsFormulaFactory(elementalFactory,weaponList,new ApsWeaponFetcher(), new ApsPercentWeaponFetcher())).CreateFormula().Evaluate());
                Console.WriteLine(weaponDmgFactory.CreateFormula().Evaluate());
                
                Console.ReadLine();

                var damageCalculator = new DamageCalculator(itemList,mainStatFetcher);
                var ehpCalculator = new EhpCalculator(itemList,myhero.HeroClass);

                var damageData = damageCalculator.GetHeroDamage(myhero.Level);
                var ehp = ehpCalculator.GetEhp(myhero.Level);

                Console.WriteLine(myhero.Name);
                Console.WriteLine("Profile Damage: {0:0.##}", damageData.ProfileDps);
                Console.WriteLine("Corrected Damage (with Set boni): {0:0.##}", damageData.CorrectedDps);
                Console.WriteLine("{0} Elemental Bonus Damage: {1:0.##}%", damageData.ElementalType, damageData.ElementalDmgPercent * 100);
                Console.WriteLine("Elemental Damage: {0:0.##}", damageData.DpsWithBoni(false, true, false));
                Console.WriteLine("Damage vs Elites Bonus: {0:0.##}%", damageData.VsElitesDmgPercent * 100);
                Console.WriteLine("vs Elites Bonus Damage: {0:0.##}", damageData.DpsWithBoni(false, true, true));
                Console.WriteLine("Cooldown Reduction: {0:0.##}%", damageData.CooldownReduction * 100);
                Console.WriteLine("Resource Cost Reduction: {0:0.##}%", damageData.ResourceCostReduction * 100);
                Console.WriteLine("Main Stats: {0:0.##}", damageData.MainStats);
                Console.WriteLine("Critical Hit Damage: {0:0.##}%", damageData.CdPercent * 100);
                Console.WriteLine("Critical Hit Chance: {0:0.##}%", damageData.CcPercent * 100);
                Console.WriteLine("Attacks per second: {0:0.##}", myhero.Stats.AttackSpeed * (1 + damageData.AtkSpdPercent));
                Console.WriteLine("eHp: {0:0.##}", ehp);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
