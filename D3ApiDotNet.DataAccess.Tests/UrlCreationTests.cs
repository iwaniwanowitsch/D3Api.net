using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D3ApiDotNet.DataAccess.API.UrlConstruction;
using D3ApiDotNet.DataAccess.API;

namespace D3ApiDotNet.DataAccess.Tests
{
    [TestClass]
    public class UrlCreationTests
    {
        [TestMethod]
        public void TestItemIconUrlCreationByExample()
        {
            var urlconstructor = new IconUrlConstructionProvider(Locales.en_GB);
            var itemid = new ApiId(@"items/large/","emerald_18_demonhunter_male");

            var url = urlconstructor.ConstructUrlFromId(itemid);

            Assert.AreEqual<string>(@"eu.media.blizzard.com/d3/icons/items/large/emerald_18_demonhunter_male.png", url);
        }

        [TestMethod]
        public void TestProfileUrlCreationByExample()
        {
            var urlconstructor = new ProfileUrlConstructionProvider(Locales.en_GB);
            var itemid = new ApiId(@"iwaniwanow#2854");

            var url = urlconstructor.ConstructUrlFromId(itemid);

            Assert.AreEqual<string>(@"eu.battle.net/api/d3/profile/iwaniwanow-2854/", url);
        }

        [TestMethod]
        public void TestHeroUrlCreationByExample()
        {
            var urlconstructor = new HeroUrlConstructionProvider(Locales.en_GB);
            var itemid = new ApiId(@"iwaniwanow#2854","38174886");

            var url = urlconstructor.ConstructUrlFromId(itemid);

            Assert.AreEqual<string>(@"eu.battle.net/api/d3/profile/iwaniwanow-2854/hero/38174886", url);
        }

        [TestMethod]
        public void TestItemUrlCreationByExample()
        {
            var urlconstructor = new ItemUrlConstructionProvider(Locales.en_GB);
            var itemid = new ApiId(@"Unique_Pants_012_x1");

            var url = urlconstructor.ConstructUrlFromId(itemid);

            Assert.AreEqual<string>(@"eu.battle.net/api/d3/data/item/Unique_Pants_012_x1", url);
        }
    }
}
