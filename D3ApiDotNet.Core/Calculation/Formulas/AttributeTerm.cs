using System;
using System.Collections.Generic;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class AttributeTerm : ITerm
    {
        private IList<Item> _items;
        private readonly IAttributeFetcher _fetcher;

        public AttributeTerm(IList<Item> items, IAttributeFetcher fetcher)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (fetcher == null) throw new ArgumentNullException("fetcher");
            Items = items;
            _fetcher = fetcher;
        }

        public IList<Item> Items
        {
            get { return _items; }
            set { if (value != null) _items = value; }
        }

        public double Evaluate()
        {
            return _fetcher.GetBonusDamage(Items) +
                   _fetcher.GetBonusDamage(Items.GetSetAttributes());
        }

        public override string ToString()
        {
            return _fetcher.GetType().Name;
        }
    }
}