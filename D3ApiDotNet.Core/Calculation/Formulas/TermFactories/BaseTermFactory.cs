using System;

namespace D3ApiDotNet.Core.Calculation.Formulas.TermFactories
{
    public class BaseTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            throw new NotSupportedException("cant create nested term in this base factory.");
        }
    }
}