using D3ApiDotNet.Core.Objects.Hero;

namespace D3ApiDotNet.WpfUI.ViewModels.Interfaces
{
    public interface IHeroViewModel : IContentViewModel
    {
        //ObservableCollection<IItemViewModel> ItemViewList { get; set; }

        IItemViewModel HeadItemViewModel { get; set; }
        IItemViewModel ShouldersItemViewModel { get; set; }
        IItemViewModel AmuletItemViewModel { get; set; }
        IItemViewModel ChestItemViewModel { get; set; }
        IItemViewModel HandItemViewModel { get; set; }
        IItemViewModel BracersItemViewModel { get; set; }
        IItemViewModel LeftRingItemViewModel { get; set; }
        IItemViewModel WaistItemViewModel { get; set; }
        IItemViewModel RightRingItemViewModel { get; set; }
        IItemViewModel MainHandItemViewModel { get; set; }
        IItemViewModel PantsItemViewModel { get; set; }
        IItemViewModel OffHandItemViewModel { get; set; }
        IItemViewModel BootsItemViewModel { get; set; }

        bool IsActualHero();

        Hero ActualHero { get; set; }
    }
}
