using System.Collections.Generic;
using System.Linq;

namespace D3Calculation.Formulas
{
    public class SumTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            return new FormulaTerm(terms, 0.0, (accumulator, current) => accumulator + current.Evaluate(),"+");
        }
    }
}