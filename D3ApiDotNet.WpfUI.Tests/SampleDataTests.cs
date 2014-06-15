using System;
using D3ApiDotNet.WpfUI.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace D3ApiDotNet.WpfUI.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void TestIfImageIsLoadedCorrectlyInItemDetailViewModelSampleData()
        {
            // Arrange
            var sampleData = new ItemDetailViewModelSampleData();

            // Assert
            Assert.IsNotNull(sampleData.Icon.Icon);
        }
    }
}
