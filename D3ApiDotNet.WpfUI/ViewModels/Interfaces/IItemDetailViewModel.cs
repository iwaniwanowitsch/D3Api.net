using System.Collections.Generic;
using D3ApiDotNet.Core.Objects.Images;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IItemDetailViewModel
    {
        Item Item { get; set; }
        D3Icon Icon { get; }
        IList<string> PrimaryAttributes { get; }
        IList<string> SecondaryAttributes { get; }
        IList<string> Gems { get; }
    }
}