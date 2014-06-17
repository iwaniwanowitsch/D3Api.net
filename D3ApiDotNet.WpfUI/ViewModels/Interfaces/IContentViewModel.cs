using System;
using System.Windows.Input;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IContentViewModel
    {
        string Name { get; }

        bool IsLoading { get; set; }

        ICommand Delete { get; }
    }
}
