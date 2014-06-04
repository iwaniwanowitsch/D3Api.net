using System;
using System.Collections.Generic;
using D3apiData.API.Objects.Item;

namespace D3Calculation.ItemFetchers
{
    interface ISetAttributesFetcher
    {
        IEnumerable<ItemAttributes> GetSetAttributes(IEnumerable<Item> items);
    }
}
