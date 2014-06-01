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
                //Console.Write("Battletag: ");
                //var battletag = Console.ReadLine();
                //Console.Write("HeroId: ");
                //var heroid = Console.ReadLine();
                var battletag = "iwaniwanow#2854";
                var heroid = "1";

                var d3api = new D3ApiServiceExample();
                d3api.Config.CollectMode = CollectMode.Online;

                var myprofile = d3api.Data.GetProfileByBattletag(battletag);

                var myhero = d3api.Data.GetHeroById(battletag, myprofile.Heroes[Convert.ToInt32(heroid)].Id.ToString());

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
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
