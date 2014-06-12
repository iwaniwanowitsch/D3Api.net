using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D3ApiDotNet.Core.Calculation.Formulas;

namespace D3ApiDotNet.Core.Tests
{
    [TestClass]
    public class FormulaTests
    {
        [TestMethod]
        public void TestMaxTermFactoryWithConstantValues()
        {
            var maxtermfactory = new MaxTermFactory();
            var constant1 = new ConstantTerm(5);
            var constant2 = new ConstantTerm(10);
            var constant3 = new ConstantTerm(2);
            var constant4 = new ConstantTerm(11); 
            var constant5 = new ConstantTerm(100);
            var constant6 = new ConstantTerm(-16);

            var maxtermcomposition = maxtermfactory.CreateFormulaTerm(constant1, constant2, constant3, constant4, constant5, constant6);
            var maxtermeval = maxtermcomposition.Evaluate();

            Assert.AreEqual<double>(100, maxtermeval);
        }

        [TestMethod]
        public void TestAverageTermFactoryWithConstantValues()
        {
            var averagetermfactory = new AverageTermFactory(new SumTermFactory(), new ProductTermFactory(), new DivisionTermFactory());
            var constant1 = new ConstantTerm(20);
            var constant2 = new ConstantTerm(20);
            var constant3 = new ConstantTerm(20);
            var constant4 = new ConstantTerm(-20);
            var constant5 = new ConstantTerm(-20);
            var constant6 = new ConstantTerm(-20);

            var averagetermcomposition = averagetermfactory.CreateFormulaTerm(constant1, constant2, constant3, constant4, constant5, constant6);
            var averageterm = averagetermcomposition.Evaluate();

            Assert.AreEqual<double>(0, averageterm);
        }
    }
}
