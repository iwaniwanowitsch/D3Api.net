using System.Collections.Generic;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public interface IItemDetailViewModel
    {
        Item Item { get; set; }
        D3Icon Icon { get; }
        IItemViewModel ItemViewModel { get; }
        IList<string> Attributes { get; }
        IList<string> Gems { get; }
    }
}