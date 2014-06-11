using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Calculation.Formulas
{
    public class MaxTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            return new ConstantTerm(terms.Max<ITerm>(term => term.Evaluate()));
        }
    }
}
