using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.SampleData
{
    class MainWindowViewModelSampleData : IMainWindowViewModel
    {
        public MainWindowViewModelSampleData()
        {
            HeroViewModel = new HeroViewModelSampleData();
        }
        public IHeroViewModel HeroViewModel { get; set; }
    }
}
