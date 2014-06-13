using System;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class AttributeTerm : ITerm
    {
        protected readonly IAttributeFetcher _fetcher;
        protected IItemListDataContainer _itemListData;

        public AttributeTerm(IItemListDataContainer itemListData, IAttributeFetcher fetcher)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            if (fetcher == null) throw new ArgumentNullException("fetcher");
            _fetcher = fetcher;
            _itemListData = itemListData;
        }

        public virtual double Evaluate()
        {
            return _fetcher.GetBonusDamage(_itemListData.GetItemList()) +
                   _fetcher.GetBonusDamage(_itemListData.GetItemList().GetSetAttributes());
        }

        public override string ToString()
        {
            return _fetcher.GetType().Name;
        }
    }
}