using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;
using D3Calculation.AttributeFetchers;
using D3Calculation.ItemFetchers;

namespace D3Calculation.Formulas
{
    public class AttributeTerm : ITerm
    {
        private List<Item> _items;
        private readonly IAttributeFetcher _fetcher;

        public AttributeTerm(List<Item> items, IAttributeFetcher fetcher)
        {
            if (items == null) throw new ArgumentNullException("items");
            if (fetcher == null) throw new ArgumentNullException("fetcher");
            Items = items;
            _fetcher = fetcher;
        }

        public List<Item> Items
        {
            get { return _items; }
            set { if (value != null) _items = value; }
        }

        public double Evaluate()
        {
            return _fetcher.GetBonusDamage(Items) +
                   _fetcher.GetBonusDamage(SetAttributesFetcher.GetSetAttributes(Items));
        }
    }
}