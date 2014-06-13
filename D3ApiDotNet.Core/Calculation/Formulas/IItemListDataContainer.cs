using D3ApiDotNet.Core.Objects.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public delegate void ItemListChangedHandler(IList<Item> itemList);

    public interface IItemListDataContainer
    {
        Func<IList<Item>> GetItemList { get; set; }
    }
}
