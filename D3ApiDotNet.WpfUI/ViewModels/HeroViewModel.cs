using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D3ApiDotNet.Core.Objects.Hero;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class HeroViewModel : IHeroViewModel
    {
        public HeroViewModel(IItemViewModel headItemViewModel, IItemViewModel shouldersItemViewModel, IItemViewModel amuletItemViewModel, IItemViewModel chestItemViewModel, IItemViewModel bracersItemViewModel, Hero actualHero, IItemViewModel bootsItemViewModel, IItemViewModel offHandItemViewModel, IItemViewModel rightRingItemViewModel, IItemViewModel waistItemViewModel, IItemViewModel leftRingItemViewModel, IItemViewModel mainHandItemViewModel, IItemViewModel pantsItemViewModel)
        {
            HeadItemViewModel = headItemViewModel;
            ShouldersItemViewModel = shouldersItemViewModel;
            AmuletItemViewModel = amuletItemViewModel;
            ChestItemViewModel = chestItemViewModel;
            BracersItemViewModel = bracersItemViewModel;
            BootsItemViewModel = bootsItemViewModel;
            OffHandItemViewModel = offHandItemViewModel;
            RightRingItemViewModel = rightRingItemViewModel;
            WaistItemViewModel = waistItemViewModel;
            LeftRingItemViewModel = leftRingItemViewModel;
            MainHandItemViewModel = mainHandItemViewModel;
            PantsItemViewModel = pantsItemViewModel;
            ActualHero = actualHero;
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
            return ActualHero != null;
        }

        public Hero ActualHero { get; set; }
    }
}
