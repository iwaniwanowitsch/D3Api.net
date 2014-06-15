using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class HeroViewModelSampleData : IHeroViewModel
    {
        public HeroViewModelSampleData()
        {
            HeadItemViewModel = new ItemViewModelSampleData();
            ShouldersItemViewModel = new ItemViewModelSampleData();
            AmuletItemViewModel = new ItemViewModelSampleData();
            ChestItemViewModel = new ItemViewModelSampleData();
            HandItemViewModel = new ItemViewModelSampleData();
            BracersItemViewModel = new ItemViewModelSampleData();
            LeftRingItemViewModel = new ItemViewModelSampleData();
            WaistItemViewModel = new ItemViewModelSampleData();
            RightRingItemViewModel = new ItemViewModelSampleData();
            MainHandItemViewModel = new ItemViewModelSampleData();
            PantsItemViewModel = new ItemViewModelSampleData();
            OffHandItemViewModel = new ItemViewModelSampleData();
            BootsItemViewModel = new ItemViewModelSampleData();
            ActualHero = null;
        }
        public IItemViewModel HeadItemViewModel { get; set; }
        public IItemViewModel ShouldersItemViewModel { get; set; }
        public IItemViewModel AmuletItemViewModel { get; set; }
        public IItemViewModel ChestItemViewModel { get; set; }
        public IItemViewModel HandItemViewModel { get; set; }
        public IItemViewModel BracersItemViewModel { get; set; }
        public IItemViewModel LeftRingItemViewModel { get; set; }
        public IItemViewModel WaistItemViewModel { get; set; }
        public IItemViewModel RightRingItemViewModel { get; set; }
        public IItemViewModel MainHandItemViewModel { get; set; }
        public IItemViewModel PantsItemViewModel { get; set; }
        public IItemViewModel OffHandItemViewModel { get; set; }
        public IItemViewModel BootsItemViewModel { get; set; }
        public bool IsActualHero()
        {
            return false;
        }

        public Hero ActualHero { get; set; }
    }
}
