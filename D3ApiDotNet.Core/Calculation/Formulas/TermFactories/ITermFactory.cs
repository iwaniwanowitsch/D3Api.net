using D3ApiDotNet.Core.Calculation.AttributeFetchers;

namespace D3ApiDotNet.Core.Calculation.Formulas.TermFactories
{
    public interface ITermFactory
    {
        ITerm CreateFormulaTerm(params ITerm[] terms);

        ITerm CreateConstantTerm(double constant);

        ITerm CreateAttributeTerm(IItemListDataContainer itemListData, IAttributeFetcher fetcher);
    }
}