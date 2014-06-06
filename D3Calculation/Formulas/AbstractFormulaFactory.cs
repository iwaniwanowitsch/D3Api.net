using System;

namespace D3Calculation.Formulas
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