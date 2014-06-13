using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public interface ITermFactory
    {
        ITerm CreateFormulaTerm(params ITerm[] terms);

        ITerm CreateConstantTerm(double constant);

        ITerm CreateAttributeTerm(EventHandler<IList<Item>> itemsChangedHandler, IAttributeFetcher fetcher);
    }
}