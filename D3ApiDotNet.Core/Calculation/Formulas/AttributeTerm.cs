using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class AttributeTerm : ITerm
    {
        private readonly IList<Item> _items;
        private readonly IAttributeFetcher _fetcher;

        public AttributeTerm(IList<Item> items, IAttributeFetcher fetcher)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (fetcher == null) throw new ArgumentNullException("fetcher");
            _items = items;
            _fetcher = fetcher;
        }

        public double Evaluate()
        {
            return _fetcher.GetBonusDamage(_items) +
                   _fetcher.GetBonusDamage(_items.GetSetAttributes());
        }

        public override string ToString()
        {
            return _fetcher.GetType().Name;
        }
    }
}