using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;

namespace D3Calculation.Formulas
{
    public interface ITermFactory
    {
        ITerm CreateFormulaTerm(params ITerm[] terms);

        ITerm CreateConstantTerm(double constant);

        ITerm CreateAttributeTerm(IList<Item> items, IAttributeFetcher fetcher);
    }
}