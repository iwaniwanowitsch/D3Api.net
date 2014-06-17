using System.Collections.ObjectModel;
using System.Linq;
using D3ApiDotNet.Core.Objects.Item;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IAllItemListViewModel : IContentViewModel
    {
        ObservableCollection<Item> AllItemList { get; set; }
    }
}
