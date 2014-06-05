using System;
using System.Collections.Generic;

namespace D3Calculation.Formulas
{
    public class BaseTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(List<ITerm> terms)
        {
            throw new NotSupportedException("cant create nested term in this base factory.");
        }
    }
}