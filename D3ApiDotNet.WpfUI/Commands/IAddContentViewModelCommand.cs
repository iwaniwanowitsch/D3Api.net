using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.Commands
{
    public interface IAddContentViewModelCommand 
    {
        void AddContentViewModel(IContentViewModel contentViewModel);
    }
}
