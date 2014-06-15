using System;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.WpfUI.Annotations;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class ItemDetailViewModel : BaseItemDetailViewModel
    {
        public ItemDetailViewModel([NotNull] Item item, [NotNull] D3Icon icon, [NotNull] IItemViewModel itemViewModel)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (icon == null) throw new ArgumentNullException("icon");
            if (itemViewModel == null) throw new ArgumentNullException("itemViewModel");
            itemViewModel.HasTooltipEnabled = false;
            Item = item;
            Icon = icon;
            ItemViewModel = itemViewModel;
        }
    }
}