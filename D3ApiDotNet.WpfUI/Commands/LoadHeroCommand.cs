using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using D3ApiDotNet.Core.Calculation;
using D3ApiDotNet.Core.Calculation.AttributeFetchers;
using D3ApiDotNet.Core.Calculation.Formulas;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class LoadHeroCommand : ICommand
    {
        private readonly ApiAccessFacade _api;
        private readonly IManageContentViewModelActions _manageContentViewModelActions;

        public LoadHeroCommand([NotNull] ApiAccessFacade api, [NotNull] IManageContentViewModelActions manageContentViewModelActions)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (manageContentViewModelActions == null) throw new ArgumentNullException("manageContentViewModelActions");
            _api = api;
            _manageContentViewModelActions = manageContentViewModelActions;
            
        }

        public ILoadDataViewModel LoadDataViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            if (LoadDataViewModel.Heroes == null)
                return false;
            return LoadDataViewModel.Heroes.Count > LoadDataViewModel.HeroId;
        }

        public async void Execute(object parameter)
        {
            if (LoadDataViewModel.HeroId < 0 || LoadDataViewModel.HeroId >= LoadDataViewModel.Heroes.Count) 
                return;
            var hero =
                LoadDataViewModel.Heroes[LoadDataViewModel.HeroId];
            if (hero == null)
                return;

            var heroViewModel = new HeroViewModel(hero, _manageContentViewModelActions, true);
            _manageContentViewModelActions.AddContentViewModel(heroViewModel);
            var skeletonHeroViewModel = new SkeletonHeroViewModel(heroViewModel);
            
            var heroMainStatFetcherLookup = new Dictionary<HeroClass, IAttributeFetcher>
                {
                    {HeroClass.Barbarian, new StrengthFetcher()},
                    {HeroClass.Crusader, new StrengthFetcher()},
                    {HeroClass.Demonhunter, new DexterityFetcher()},
                    {HeroClass.Monk, new DexterityFetcher()},
                    {HeroClass.Witchdoctor, new IntelligenceFetcher()},
                    {HeroClass.Wizard, new IntelligenceFetcher()}
                };

            var mainStatFetcher = heroMainStatFetcherLookup[hero.HeroClass];

            var itemListContainer = new ItemListDataContainer(() => heroViewModel.ItemList);

            var statsHeroViewModel =
                new StatsHeroViewModel(new DamageTermComposite(hero.Level, mainStatFetcher, itemListContainer),
                    new EhpTermComposite(hero.Level, itemListContainer, hero.HeroClass), heroViewModel);

            heroViewModel.SkeletonHeroViewModel = skeletonHeroViewModel;
            heroViewModel.StatsViewModel = statsHeroViewModel;

            var items = hero.Items;
            var head = items.Head != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Head.TooltipParams)) : null;
            var shoulders = items.Shoulders != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Shoulders.TooltipParams)) : null;
            var amulet = items.Neck != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Neck.TooltipParams)) : null;
            var hands = items.Hands != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Hands.TooltipParams)) : null;
            var chest = items.Torso != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Torso.TooltipParams)) : null;
            var bracers = items.Bracers != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Bracers.TooltipParams)) : null;
            var leftRing = items.LeftFinger != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.LeftFinger.TooltipParams)) : null;
            var waist = items.Waist != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Waist.TooltipParams)) : null;
            var rightRing = items.RightFinger != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.RightFinger.TooltipParams)) : null;
            var mainHand = items.MainHand != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.MainHand.TooltipParams)) : null;
            var pants = items.Legs != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Legs.TooltipParams)) : null;
            var offHand = items.OffHand != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.OffHand.TooltipParams)) : null;
            var boots = items.Feet != null ? await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Feet.TooltipParams)) : null;

            var iconsize = ItemIconSizes.Small;

            var headicon = head != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(head.Icon,iconsize)) : null;
            var shouldersicon = shoulders != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(shoulders.Icon, iconsize)) : null;
            var amuleticon = amulet != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(amulet.Icon, iconsize)) : null;
            var chesticon = chest != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(chest.Icon, iconsize)) : null;
            var bracersicon = bracers != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(bracers.Icon, iconsize)) : null;
            var handsicon = hands != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(hands.Icon, iconsize)) : null;
            var bootsicon = boots != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(boots.Icon, iconsize)) : null;
            var offHandicon = offHand != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(offHand.Icon, iconsize)) : null;
            var rightRingicon = rightRing != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(rightRing.Icon, iconsize)) : null;
            var waisticon = waist != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(waist.Icon, iconsize)) : null;
            var leftRingicon = leftRing != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(leftRing.Icon, iconsize)) : null;
            var mainHandicon = mainHand != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(mainHand.Icon, iconsize)) : null;
            var pantsicon = pants != null ? await Task.Factory.StartNew(() => _api.ItemIconRepository.GetByIdAndSize(pants.Icon, iconsize)) : null;

            heroViewModel.HeadItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(head, headicon));
            heroViewModel.ShouldersItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(shoulders, shouldersicon));
            heroViewModel.AmuletItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(amulet, amuleticon));
            heroViewModel.ChestItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(chest, chesticon));
            heroViewModel.BracersItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(bracers, bracersicon));
            heroViewModel.HandItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(hands, handsicon));
            heroViewModel.BootsItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(boots, bootsicon));
            heroViewModel.OffHandItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(offHand, offHandicon));
            heroViewModel.RightRingItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(rightRing, rightRingicon));
            heroViewModel.WaistItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(waist, waisticon));
            heroViewModel.LeftRingItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(leftRing, leftRingicon));
            heroViewModel.MainHandItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(mainHand, mainHandicon));
            heroViewModel.PantsItemViewModel = new ItemViewModel(true, new ItemDetailViewModel(pants, pantsicon));
            heroViewModel.IsLoading = false;
        }

        public void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}