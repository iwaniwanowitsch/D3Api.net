using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public abstract class AbstractTermFactory : ITermFactory
    {
        public abstract ITerm CreateFormulaTerm(params ITerm[] terms);

        public virtual ITerm CreateConstantTerm(double constant)
        {
            return new ConstantTerm(constant);
        }

        public virtual ITerm CreateAttributeTerm(IList<Item> items, IAttributeFetcher fetcher)
        {
            return new AttributeTerm(items, fetcher);
        }
    }
}