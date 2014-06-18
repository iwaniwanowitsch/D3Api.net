using System;
using D3ApiDotNet.Core.NotifyPropertyChanged;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class ItemViewModel : BaseNotifyPropertyChanged, IItemViewModel
    {
        private IItemDetailViewModel _itemDetailViewModel;

        public ItemViewModel(bool hasTooltipEnabled, [NotNull] IItemDetailViewModel itemDetailViewModel)
        {
            if (itemDetailViewModel == null) throw new ArgumentNullException("itemDetailViewModel");
            HasTooltipEnabled = hasTooltipEnabled;
            ItemDetailViewModel = itemDetailViewModel;
        }

        public bool HasTooltipEnabled { get; set; }

        public IItemDetailViewModel ItemDetailViewModel
        {
            get { return _itemDetailViewModel; }
            private set { this.SetValueIfChanged(ref _itemDetailViewModel, value); }
        }
    }
}