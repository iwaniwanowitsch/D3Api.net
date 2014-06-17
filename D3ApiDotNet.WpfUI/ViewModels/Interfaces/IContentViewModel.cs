using System;
using System.Windows.Input;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IContentViewModel
    {
        string Name { get; }

        ICommand Delete { get; }
    }
}
