using System;
using System.Windows.Input;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;
using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Item;
using System.Collections.Generic;

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
            ActualHero = new Hero { Level = 70, ParagonLevel = 243, HeroClass = HeroClass.Monk, Name = "geiler Hero", Kills = new HeroKills { Elites = 100 } };
            IsLoading = true;
            SkeletonHeroViewModel = new SkeletonHeroViewModel(this);
            StatsViewModel = new StatsHeroViewModel(new DamageTermComposite(ActualHero.Level, new DexterityFetcher(), new ItemListDataContainer(() => new List<Item>{HeadItemViewModel.ItemDetailViewModel.Item})), new EhpTermComposite(ActualHero.Level, new ItemListDataContainer(() => new List<Item>()), ActualHero.HeroClass), this);
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

        public string Name
        {
            get { return "HeroView"; }
        }

        public bool IsLoading { get; set; }

        public ICommand Delete
        {
            get { return null; }
        }

        public ISkeletonHeroViewModel SkeletonHeroViewModel { get; set; }

        public IStatsHeroViewModel StatsViewModel { get; set; }
    }
}
