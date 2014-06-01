using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using D3apiData;
using D3apiData.API;
using D3apiData.API.Objects.Hero;
using D3apiData.API.Objects.Item;
using D3Calculation.BonusDamageCalc;
using D3Calculation.SetCalc;

namespace D3Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                var battletag = "iwaniwanow#2854";

                var d3api = new D3ApiServiceExample();
                d3api.Config.CollectMode = CollectMode.Online;

                var myprofile = d3api.Data.GetProfileByBattletag(battletag);

                Console.WriteLine("Profile: {0}", battletag);
                for (var i = 0; i < myprofile.Heroes.Length; i++)
                {
                    Console.WriteLine("({0}) {1}",i,myprofile.Heroes[i].Name);
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
                Console.WriteLine();

                var myhero = d3api.Data.GetHeroById(battletag, myprofile.Heroes[heroid].Id.ToString());

                var damageCalculator = new DamageCalculator(d3api.Data);
                var damageData = damageCalculator.GetHeroDamage(myhero);

                Console.WriteLine(myhero.Name);
                Console.WriteLine("Profile Damage: {0:0.##}", damageData.ProfileDps);
                Console.WriteLine("Corrected Damage (with Set boni): {0:0.##}", damageData.CorrectedDps);
                Console.WriteLine("{0} Elemental Bonus Damage: {1:0.##}%", damageData.ElementalType, damageData.ElementalDmgPercent * 100);
                Console.WriteLine("Elemental Damage: {0:0.##}", damageData.DpsWithBoni(false,true,false));
                Console.WriteLine("Damage vs Elites Bonus: {0:0.##}%", damageData.VsElitesDmgPercent * 100);
                Console.WriteLine("vs Elites Bonus Damage: {0:0.##}", damageData.DpsWithBoni(false,true,true));
                Console.WriteLine("Cooldown Reduction: {0:0.##}%",damageData.CooldownReduction*100);
                Console.WriteLine("Resource Cost Reduction: {0:0.##}%", damageData.ResourceCostReduction * 100);
                Console.WriteLine("Main Stats: {0:0.##}",damageData.MainStats);
                Console.WriteLine("Critical Hit Damage: {0:0.##}%", damageData.CdPercent * 100);
                Console.WriteLine("Critical Hit Chance: {0:0.##}%", damageData.CcPercent * 100);
                Console.WriteLine("Attacks per second: {0:0.##}", myhero.Stats.AttackSpeed * (1 + damageData.AtkSpdPercent));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
