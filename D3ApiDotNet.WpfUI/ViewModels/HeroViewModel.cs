using System;
using System.Collections.ObjectModel;
using D3ApiDotNet.Core.NotifyPropertyChanged;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class HeroViewModel : BaseContentViewModel, IHeroViewModel
    {

        ISkeletonHeroViewModel _skeletonHeroViewModel;
        IStatsHeroViewModel _statsHeroViewModel;
        private IItemViewModel _headItemViewModel;
        private IItemViewModel _shouldersItemViewModel;
        private IItemViewModel _amuletItemViewModel;
        private IItemViewModel _chestItemViewModel;
        private IItemViewModel _handItemViewModel;
        private IItemViewModel _bracersItemViewModel;
        private IItemViewModel _leftRingItemViewModel;
        private IItemViewModel _waistItemViewModel;
        private IItemViewModel _rightRingItemViewModel;
        private IItemViewModel _mainHandItemViewModel;
        private IItemViewModel _pantsItemViewModel;
        private IItemViewModel _offHandItemViewModel;
        private IItemViewModel _bootsItemViewModel;

        public HeroViewModel(Hero actualHero, [NotNull] IManageContentViewModelActions manageContentViewModelActions,
            bool isLoading)
            : base(manageContentViewModelActions, true, isLoading)
        {
            ActualHero = actualHero;
        }

        public HeroViewModel(IItemViewModel headItemViewModel, IItemViewModel shouldersItemViewModel, IItemViewModel amuletItemViewModel, IItemViewModel chestItemViewModel, IItemViewModel bracersItemViewModel, IItemViewModel handItemViewModel, IItemViewModel bootsItemViewModel, IItemViewModel offHandItemViewModel, IItemViewModel rightRingItemViewModel, IItemViewModel waistItemViewModel, IItemViewModel leftRingItemViewModel, IItemViewModel mainHandItemViewModel, IItemViewModel pantsItemViewModel, Hero actualHero, [NotNull] IManageContentViewModelActions manageContentViewModelActions, bool isLoading)
            : this(actualHero, manageContentViewModelActions, isLoading)
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
            HandItemViewModel = handItemViewModel;
        }

        public IItemViewModel HeadItemViewModel
        {
            get { return _headItemViewModel; }
            set { this.SetValueIfChanged(ref _headItemViewModel, value); }
        }

        public IItemViewModel ShouldersItemViewModel
        {
            get { return _shouldersItemViewModel; }
            set { this.SetValueIfChanged(ref _shouldersItemViewModel, value); }
        }

        public IItemViewModel AmuletItemViewModel
        {
            get { return _amuletItemViewModel; }
            set { this.SetValueIfChanged(ref _amuletItemViewModel, value); }
        }

        public IItemViewModel ChestItemViewModel
        {
            get { return _chestItemViewModel; }
            set { this.SetValueIfChanged(ref _chestItemViewModel, value); }
        }

        public IItemViewModel HandItemViewModel
        {
            get { return _handItemViewModel; }
            set { this.SetValueIfChanged(ref _handItemViewModel, value); }
        }

        public IItemViewModel BracersItemViewModel
        {
            get { return _bracersItemViewModel; }
            set { this.SetValueIfChanged(ref _bracersItemViewModel, value); }
        }

        public IItemViewModel LeftRingItemViewModel
        {
            get { return _leftRingItemViewModel; }
            set { this.SetValueIfChanged(ref _leftRingItemViewModel, value); }
        }

        public IItemViewModel WaistItemViewModel
        {
            get { return _waistItemViewModel; }
            set { this.SetValueIfChanged(ref _waistItemViewModel, value); }
        }

        public IItemViewModel RightRingItemViewModel
        {
            get { return _rightRingItemViewModel; }
            set { this.SetValueIfChanged(ref _rightRingItemViewModel, value); }
        }

        public IItemViewModel MainHandItemViewModel
        {
            get { return _mainHandItemViewModel; }
            set { this.SetValueIfChanged(ref _mainHandItemViewModel, value); }
        }

        public IItemViewModel PantsItemViewModel
        {
            get { return _pantsItemViewModel; }
            set { this.SetValueIfChanged(ref _pantsItemViewModel, value); }
        }

        public IItemViewModel OffHandItemViewModel
        {
            get { return _offHandItemViewModel; }
            set { this.SetValueIfChanged(ref _offHandItemViewModel, value); }
        }

        public IItemViewModel BootsItemViewModel
        {
            get { return _bootsItemViewModel; }
            set { this.SetValueIfChanged(ref _bootsItemViewModel, value); }
        }

        public bool IsActualHero()
        {
            return ActualHero != null;
        }

        public Hero ActualHero { get; set; }

        public override string Name
        {
            get
            {
                if (ActualHero != null)
                    return "HeroView: " + ActualHero.Name;
                return "HeroView";
            }
        }

        public ObservableCollection<Item> ItemList
        {
            get
            {
                var list = new ObservableCollection<Item>();
                if (HeadItemViewModel != null)
                    list.Add(HeadItemViewModel.ItemDetailViewModel.Item);
                if (ShouldersItemViewModel != null)
                    list.Add(ShouldersItemViewModel.ItemDetailViewModel.Item);
                if (AmuletItemViewModel != null)
                    list.Add(AmuletItemViewModel.ItemDetailViewModel.Item);
                if (ChestItemViewModel != null)
                    list.Add(ChestItemViewModel.ItemDetailViewModel.Item);
                if (HandItemViewModel != null)
                    list.Add(HandItemViewModel.ItemDetailViewModel.Item);
                if (BracersItemViewModel != null)
                    list.Add(BracersItemViewModel.ItemDetailViewModel.Item);
                if (LeftRingItemViewModel != null)
                    list.Add(LeftRingItemViewModel.ItemDetailViewModel.Item);
                if (WaistItemViewModel != null)
                    list.Add(WaistItemViewModel.ItemDetailViewModel.Item);
                if (RightRingItemViewModel != null)
                    list.Add(RightRingItemViewModel.ItemDetailViewModel.Item);
                if (MainHandItemViewModel != null)
                    list.Add(MainHandItemViewModel.ItemDetailViewModel.Item);
                if (PantsItemViewModel != null)
                    list.Add(PantsItemViewModel.ItemDetailViewModel.Item);
                if (OffHandItemViewModel != null)
                    list.Add(OffHandItemViewModel.ItemDetailViewModel.Item);
                if (BootsItemViewModel != null)
                    list.Add(BootsItemViewModel.ItemDetailViewModel.Item);
                return list;
            }
        }

        public ISkeletonHeroViewModel SkeletonHeroViewModel
        {
            get
            {
                return _skeletonHeroViewModel;
            }
            set
            {
                this.SetValueIfChanged(ref _skeletonHeroViewModel, value);
            }
        }

        public IStatsHeroViewModel StatsViewModel
        {
            get
            {
                return _statsHeroViewModel;
            }
            set
            {
                this.SetValueIfChanged(ref _statsHeroViewModel, value);
            }
        }
    }
}
