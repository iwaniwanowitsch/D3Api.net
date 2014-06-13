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

        public AttributeTerm(EventHandler<IList<Item>> itemsChangedHandler, IAttributeFetcher fetcher)
        {
            if (itemsChangedHandler == null) throw new ArgumentNullException("itemListChangedEvent");
            if (fetcher == null) throw new ArgumentNullException("fetcher");
            itemsChangedHandler += UpdateItems;
            _fetcher = fetcher;
        }

        public void UpdateItems(object o, IList<Item> items)
        {
            if (items == null) throw new ArgumentNullException("items");
            _items = items;
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