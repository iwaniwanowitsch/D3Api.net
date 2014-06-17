using System.Collections.ObjectModel;
using D3ApiDotNet.WpfUI.Commands;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IMainWindowViewModel : IManageContentViewModelActions
    {
        ObservableCollection<IContentViewModel> ContentViewModels { get; set; }

    }
}
