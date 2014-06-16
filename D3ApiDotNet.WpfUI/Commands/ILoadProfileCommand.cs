using System.Windows.Input;

namespace D3ApiDotNet.WpfUI.Commands
{
    public interface ILoadProfileCommand : ICommand
    {
        void OnCanExecuteChanged();
    }
}
