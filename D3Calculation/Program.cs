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

namespace D3Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Battletag: ");
                var battletag = Console.ReadLine();
                Console.Write("HeroId: ");
                var heroid = Console.ReadLine();

                var d3api = new D3ApiServiceExample();

                var myprofile = d3api.Data.GetProfileByBattletag(battletag);

                var myhero = d3api.Data.GetHeroById(battletag, myprofile.Heroes[Convert.ToInt32(heroid)].Id.ToString());

                var itemTooltipList = new List<string>
                {
                    myhero.Items.Head.TooltipParams,
                    myhero.Items.Bracers.TooltipParams,
                    myhero.Items.Feet.TooltipParams,
                    myhero.Items.Hands.TooltipParams,
                    myhero.Items.LeftFinger.TooltipParams,
                    myhero.Items.Legs.TooltipParams,
                    myhero.Items.Neck.TooltipParams,
                    myhero.Items.RightFinger.TooltipParams,
                    myhero.Items.Shoulders.TooltipParams,
                    myhero.Items.Torso.TooltipParams,
                    myhero.Items.Waist.TooltipParams,
                    myhero.Items.MainHand.TooltipParams,
                    myhero.Items.OffHand.TooltipParams
                };

                var itemList = itemTooltipList.Select(o => d3api.Data.GetItemByTooltipParams(o));

                var bonusDmgCalcList = new Dictionary<string, IBonusDamageCalculator>
                {
                    {"Arcane", new ArcaneBonusBonusDamageCalculator()},
                    {"Cold", new ColdBonusBonusDamageCalculator()},
                    {"Fire", new FireBonusBonusDamageCalculator()},
                    {"Holy", new HolyBonusBonusDamageCalculator()},
                    {"Lightning", new LightningBonusBonusDamageCalculator()},
                    {"Physical", new PhysicalBonusBonusDamageCalculator()},
                    {"Poison", new PoisonBonusBonusDamageCalculator()}
                };

                var bonusDmgList =
                    bonusDmgCalcList.Select(
                        pair => new KeyValuePair<string, double>(pair.Key, pair.Value.GetBonusDamage(itemList)));
                var maxDmgBonusValue = bonusDmgList.Max(o => o.Value);
                var maxDmgBonus =
                    bonusDmgList.FirstOrDefault(o => Math.Abs(o.Value - maxDmgBonusValue) < 0.0001);
                var elitesBonusDmgCalc = new ElitesBonusBonusDamageCalculator();
                var elitesBonusDmg = elitesBonusDmgCalc.GetBonusDamage(itemList);

                Console.WriteLine(myhero.Name);
                Console.WriteLine("Damage: {0:0.##}", myhero.Stats.Damage);
                Console.WriteLine("{0} Elemental Bonus Damage: {1:0.##}", maxDmgBonus.Key, maxDmgBonus.Value);
                var elementalDmg = (1 + maxDmgBonus.Value)*myhero.Stats.Damage;
                Console.WriteLine("Elemental Damage: {0:0.##}", elementalDmg);
                Console.WriteLine("Damage vs Elites Bonus: {0:0.##}", elitesBonusDmg);
                var totalDmg = elementalDmg*(1 + elitesBonusDmg);
                Console.WriteLine("Elemental and vs Elites Damage: {0:0.##}", totalDmg);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
