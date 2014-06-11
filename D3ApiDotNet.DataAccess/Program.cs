using System;
using System.IO;
using System.Net;
using D3ApiDotNet.DataAccess.API.FilepathProviders;
using D3ApiDotNet.DataAccess.API.UrlConstruction;
using D3ApiDotNet.DataAccess.Repositories;

namespace D3ApiDotNet.DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // composition root

            var locale = Locales.en_GB;
            var cachepath = @"cache\";

            var profileUrlConstructor = new ProfileUrlConstructionProvider(locale);
            var heroUrlConstructor = new HeroUrlConstructionProvider(locale);
            var itemUrlConstructor = new ItemUrlConstructionProvider(locale);
            var followerUrlConstructor = new FollowerUrlConstructionProvider(locale);
            var artisanUrlConstructor = new ArtisanUrlConstructionProvider(locale);
            var iconUrlConstructor = new IconUrlConstructionProvider(locale);

            var defaultFilePathProvider = new DefaultFilePathProvider(); // end of chain
            var iconFilePathProvider = new IconFilePathProvider(defaultFilePathProvider,cachepath);
            var itemFilePathProvider = new ItemFilePathProvider(iconFilePathProvider, cachepath);
            var profileFilePathProvider = new ProfileFilePathProvider(itemFilePathProvider, cachepath);
            var heroFilePathProvider = new HeroFilePathProvider(profileFilePathProvider,cachepath); // begin of chain

            var readRepo = new StreamWebRepository(null);
            var writeRepo = new StreamCacheFileFromUrlRepository(new TimeSpan(0, 0, 15, 0), heroFilePathProvider);
            var readRepoDecorated = new TryCacheRepositoryDecorator<Stream, string>(readRepo,writeRepo);

            var profileRepository = new ProfileRepository(readRepoDecorated, profileUrlConstructor);
            var heroRepository = new HeroRepository(readRepoDecorated, heroUrlConstructor);
            var itemRepository = new ItemRepository(readRepoDecorated, itemUrlConstructor);
            var followerRepository = new FollowerRepository(readRepoDecorated, followerUrlConstructor);
            var artisanRepository = new ArtisanRepository(readRepoDecorated, artisanUrlConstructor);
            var skillIconRepository = new SkillIconRepository(readRepoDecorated, iconUrlConstructor);
            var itemIconRepository = new ItemIconRepository(readRepoDecorated, iconUrlConstructor);

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
            var hero = heroRepository.GetByBattletagAndId("iwaniwanow#2854","41139248");
            //var icon = api.Data.GetItemIconById("unique_helm_014_x1_demonhunter_male");

            //api.Config.CollectMode = CollectMode.TryCacheThenOnline;

            //api.Data.Battletag = "iwaniwanow#2854";
            var item = itemRepository.GetByTooltipParams("item/ClYIy-bypQwSBwgEFaLQXCIdyfq8oB1-dlWhHZsGAMsddEWniR3z1Ue0MIsCOI4CQABQElgEYJMCgAFGpQF0RaeJrQF-VrMutQHJW5KkuAGm0s_XAcABBxjEwualBFAIWAI");
            Console.WriteLine(hero.Name);

            Console.ReadLine();
        }
    }
}
