using System;
using System.Collections.ObjectModel;
using D3ApiDotNet.WpfUI.Annotations;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel([NotNull] ObservableCollection<IContentViewModel> contentViewModels)
        {
            if (contentViewModels == null) throw new ArgumentNullException("contentViewModels");
            ContentViewModels = contentViewModels;
        }

        public void AddContentViewModel(IContentViewModel contentViewModel)
        {
            ContentViewModels.Add(contentViewModel);
        }

        public ObservableCollection<IContentViewModel> ContentViewModels { get; set; }
    }
}