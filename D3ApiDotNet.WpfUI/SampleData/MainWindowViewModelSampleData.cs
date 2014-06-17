using System.Collections.Generic;
using System.Collections.ObjectModel;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.SampleData
{
    class MainWindowViewModelSampleData : IMainWindowViewModel
    {
        public MainWindowViewModelSampleData()
        {
            ContentViewModels = new ObservableCollection<IContentViewModel> { new HeroViewModelSampleData(), new HeroViewModelSampleData() };
        }
        public ObservableCollection<IContentViewModel> ContentViewModels { get; set; }
        public void AddContentViewModel(IContentViewModel contentViewModel)
        {
            ContentViewModels.Add(contentViewModel);
        }
    }
}
