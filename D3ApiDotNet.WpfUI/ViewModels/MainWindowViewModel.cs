using System;
using System.Collections.ObjectModel;
using System.Linq;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private ObservableCollection<IContentViewModel> _contentViewModels;

        public MainWindowViewModel([NotNull] ObservableCollection<IContentViewModel> contentViewModels)
        {
            if (contentViewModels == null) throw new ArgumentNullException("contentViewModels");
            ContentViewModels = contentViewModels;
        }

        public void AddContentViewModel(IContentViewModel contentViewModel)
        {
            if (ContentViewModels.All(o => contentViewModel.Name != o.Name))
            ContentViewModels.Add(contentViewModel);
        }

        public ObservableCollection<IContentViewModel> ContentViewModels
        {
            get { return _contentViewModels; }
            set
            {
                if (value == null) return;
                _contentViewModels = value; 
            }
        }
    }
}