using System;
using System.Collections.Generic;
using System.IO;
using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.ItemFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.TextConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            var dosome = new DoSomethingClassCausImHip();
            dosome.DoSomething();
        }
    }

    public class DoSomethingClassCausImHip
    {

        private List<Item> _itemList = new List<Item>();

        private IList<Item> GetItems()
        {
            return _itemList;
        }

        public void DoSomething()
        {
            //ConfigureContainer;
            //var damageCalculator = container.Resolve<IDamageCalculator>();
            var d3Api = new ApiAccessFacade(CollectMode.TryCacheThenOnline, Locales.en_GB, null/*new System.Net.WebProxy("127.0.0.1:3128")*/, new TimeSpan(0,0,15,0));
            var itemListFetcher = new HeroItemsFetcher(d3Api.ItemRepository);
            
            var listDataContainer = new ItemListDataContainer(GetItems);
            do
            {
                Console.Clear();
                //var battletag = "iwaniwanow#2854";
                Console.SetCursorPosition(0, 0);
                Console.Write("Enter Battletag: ");
                var battletag = Console.ReadLine();

                var myprofile = d3Api.ProfileRepository.GetByBattletag(battletag);
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

                var myhero = d3Api.HeroRepository.GetByBattletagAndId(battletag, myprofile.Heroes[heroid].Id.ToString());

                // hero items list
                _itemList = itemListFetcher.GetItemsList(myhero);
                //var weaponList = _itemList.Where(o => o.AttacksPerSecond != null).ToList();

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

                var damageCalculationComposite = new DamageTermComposite(myhero.Level, mainStatFetcher, listDataContainer);
                var ehpCalculationComposite = new EhpTermComposite(myhero.Level, listDataContainer, myhero.HeroClass);

                Console.WriteLine(myhero.Name);
                Console.WriteLine("Profile Damage: {0:0.##}", myhero.Stats.Damage);
                Console.WriteLine("Corrected Damage (with Set boni): {0:0.##}", damageCalculationComposite.Evaluate());
                Console.WriteLine("{0} Elemental Bonus Damage: {1:0.##}%", damageCalculationComposite.ElementalDamageFactory.MaxElementToString(), damageCalculationComposite.ElementalDamageFactory.CreateFormula().Evaluate() * 100);
                Console.WriteLine("Elemental Damage: {0:0.##}", damageCalculationComposite.DamageWithElemental.Evaluate());
                Console.WriteLine("Damage vs Elites Bonus: {0:0.##}%", damageCalculationComposite.VsElitesDamageTerm.Evaluate() * 100);
                Console.WriteLine("vs Elites Bonus Damage: {0:0.##}", damageCalculationComposite.DamageWithElementalAndVsElites.Evaluate());
                Console.WriteLine("Cooldown Reduction: {0:0.##}%", damageCalculationComposite.CooldownReductionTerm.Evaluate());
                Console.WriteLine("Resource Cost Reduction: {0:0.##}%", damageCalculationComposite.ResourceCostReductionTerm.Evaluate() * 100);
                Console.WriteLine("Main Stats: {0:0.##}", damageCalculationComposite.MainStatTerm.Evaluate());
                Console.WriteLine("Critical Hit Damage: {0:0.##}%", damageCalculationComposite.CriticalHitDamageTerm.Evaluate());
                Console.WriteLine("Critical Hit Chance: {0:0.##}%", damageCalculationComposite.CriticalHitChanceTerm.Evaluate());
                Console.WriteLine("Attacks per second: {0:0.##}", damageCalculationComposite.AttacksPerSecond.Evaluate());
                Console.WriteLine("eHp: {0:0.##}", ehpCalculationComposite.Evaluate());
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
