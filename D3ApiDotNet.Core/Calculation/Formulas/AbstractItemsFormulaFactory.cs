using D3ApiDotNet.Core.Objects.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3ApiDotNet.Core.Calculation.Formulas
{
    public abstract class AbstractItemsFormulaFactory : AbstractFormulaFactory
    {
        protected readonly IItemListDataContainer ItemListData;
        protected IList<Item> ItemList
        {
            get
            {
                return ItemListData.GetItemList();
            }
        }
        protected IList<Item> WeaponList {
            get
            {
                return ItemList.Where<Item>(o => o.AttacksPerSecond != null).ToList<Item>();
            }
        }

        protected AbstractItemsFormulaFactory(ElementalTermFactories factories, IItemListDataContainer itemListData)
            : base(factories)
        {
            if (itemListData == null) throw new ArgumentNullException("itemListData");
            ItemListData = itemListData;
        }

        public override abstract ITerm CreateFormula();
    }
}
