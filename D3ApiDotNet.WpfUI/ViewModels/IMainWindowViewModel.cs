using System.Collections.ObjectModel;
using D3ApiDotNet.WpfUI.Commands;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public interface IMainWindowViewModel : IAddContentViewModelCommand
    {
        ObservableCollection<IContentViewModel> ContentViewModels { get; set; }
    }
}
