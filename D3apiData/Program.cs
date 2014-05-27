using System;
using D3apiData.API;

namespace D3apiData
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new D3Api();
            //Console.WriteLine(data.Config.Locale);

            /*ItemNamesCollector collector = new ItemNamesCollector(data.Webclient);
            List<string> results = collector.GetAllItemNames(@"http://eu.battle.net", "en");
            Console.WriteLine(results.Count);
            System.IO.File.WriteAllLines(@"items.txt", results);*/

            //Console.WriteLine(SkillIconSizes.large);
            //Console.WriteLine(CacheCollector.GetMd5Hash(@"http://eu.battle.net").Length);
            //api.Config.Locale = Locales.de_DE;

            //var profile = api.Data.GetProfileByBattletag("iwaniwanow#2854");
            //api.Data.Battletag = "iwaniwanow#2854";
            //var hero = api.Data.GetHeroById("41139248");
            //var icon = api.Data.GetItemIconById("unique_helm_014_x1_demonhunter_male");
            api.Config.CollectMode = CollectMode.TryCacheThenOnline;
            var item = api.Data.GetItemById("Unique_Ring_107_x1");
            Console.WriteLine(item.Name);

            Console.ReadLine();
            api.SaveConfig();
        }
    }
}
