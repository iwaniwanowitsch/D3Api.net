using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.Commands
{
    public interface IAddContentViewModelCommand 
    {
        void AddContentViewModel(IContentViewModel contentViewModel);
    }
}
