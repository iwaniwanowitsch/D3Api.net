using D3ApiDotNet.Core.Calculation.AttributeFetchers;

namespace D3ApiDotNet.Core.Calculation.Formulas.TermFactories
{
    public abstract class AbstractTermFactory : ITermFactory
    {
        public abstract ITerm CreateFormulaTerm(params ITerm[] terms);

        public virtual ITerm CreateConstantTerm(double constant)
        {
            return new ConstantTerm(constant);
        }

        public virtual ITerm CreateAttributeTerm(IItemListDataContainer itemListData, IAttributeFetcher fetcher)
        {
            return new AttributeTerm(itemListData, fetcher);
        }
    }
}