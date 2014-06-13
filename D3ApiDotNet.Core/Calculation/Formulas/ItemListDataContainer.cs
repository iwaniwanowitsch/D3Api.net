using D3ApiDotNet.Core.Objects.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public class ItemListDataContainer : IItemListDataContainer
    {
        public Func<IList<Item>> GetItemList { get; set; }

        public ItemListDataContainer(Func<IList<Item>> getItemList)
        {
            GetItemList = getItemList;
        }
    }
}
