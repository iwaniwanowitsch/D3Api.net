using System;
using D3ApiDotNet.Core.Calculation.Formulas.TermFactories;

namespace D3ApiDotNet.Core.Calculation.Formulas.FormulaFactories
{

    public abstract class AbstractFormulaFactory : IFormulaFactory
    {
        protected readonly ElementalTermFactories Factories;

        protected AbstractFormulaFactory(ElementalTermFactories factories)
        {
            if (factories == null) throw new ArgumentNullException("factories");
            Factories = factories;
        }

        public abstract ITerm CreateFormula();
    }
}