using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D3ApiDotNet.DataAccess.API.FilepathProviders.Factories;

namespace D3ApiDotNet.DataAccess.Tests
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für FilepathCreationTests
    /// </summary>
    [TestClass]
    public class FilepathCreationTests
    {
        [TestMethod]
        public void TestItemFilepathCreationByExample()
        {
            var filepathproviderfactory = new FilePathProviderChainFactory();
            var filepathproviderchain = filepathproviderfactory.CreateFilePathProvider("");

            var filepath = filepathproviderchain.BuildFilePath(@"http://eu.battle.net/api/d3/data/item/Unique_Pants_012_x1");

            Assert.AreEqual<string>(@"item\Unique_Pants_012_x1.json", filepath);
        }

        [TestMethod]
        public void TestProfileFilepathCreationByExample()
        {
            var filepathproviderfactory = new FilePathProviderChainFactory();
            var filepathproviderchain = filepathproviderfactory.CreateFilePathProvider("");

            var filepath = filepathproviderchain.BuildFilePath(@"http://eu.battle.net/api/d3/profile/iwaniwanow-2854/");

            Assert.AreEqual<string>(@"profile\iwaniwanow-2854.json", filepath);
        }

        [TestMethod]
        public void TestHeroFilepathCreationByExample()
        {
            var filepathproviderfactory = new FilePathProviderChainFactory();
            var filepathproviderchain = filepathproviderfactory.CreateFilePathProvider("");

            var filepath = filepathproviderchain.BuildFilePath(@"http://eu.battle.net/api/d3/profile/iwaniwanow-2854/hero/38174886");

            Assert.AreEqual<string>(@"profile\iwaniwanow-2854\hero\38174886.json", filepath);
        }
    }
}
