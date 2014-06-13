using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
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