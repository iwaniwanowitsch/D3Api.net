using System.ComponentModel;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public interface IItemViewModel
    {
        bool HasTooltipEnabled { get; set; }
        IItemDetailViewModel ItemDetailViewModel { get; }
    }
}
