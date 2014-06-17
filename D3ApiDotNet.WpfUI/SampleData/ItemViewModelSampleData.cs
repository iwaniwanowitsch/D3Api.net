using System.ComponentModel;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess.Repositories;
using D3ApiDotNet.WpfUI.ViewModels;
using System.Drawing;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using D3ApiDotNet.WpfUI.Views;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class ItemViewModelSampleData : IItemViewModel
    {
        public bool HasTooltipEnabled { get; set; }
        public IItemDetailViewModel ItemDetailViewModel { get; private set; }

        public ItemViewModelSampleData()
        {
            HasTooltipEnabled = true;
            ItemDetailViewModel = new ItemDetailViewModelSampleData();
        }
    }   
}
