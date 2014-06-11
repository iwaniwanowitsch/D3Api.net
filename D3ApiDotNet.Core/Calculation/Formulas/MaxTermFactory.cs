using System.Linq;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class MaxTermFactory : AbstractTermFactory
    {
        public override ITerm CreateFormulaTerm(params ITerm[] terms)
        {
            return new ConstantTerm(terms.Max<ITerm>(term => term.Evaluate()));
        }
    }
}
