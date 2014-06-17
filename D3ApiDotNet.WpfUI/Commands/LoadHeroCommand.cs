using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
            var hero =
                LoadDataViewModel.Heroes[LoadDataViewModel.HeroId];
            if (hero == null)
                return;
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

            _manageContentViewModelActions.AddContentViewModel(
                new HeroViewModel(
                    head != null ? new ItemViewModel(true, new ItemDetailViewModel(head,_api.ItemIconRepository.GetByIdAndSize(head.Icon,ItemIconSizes.Small))) : null,
                    shoulders != null ? new ItemViewModel(true, new ItemDetailViewModel(shoulders, _api.ItemIconRepository.GetByIdAndSize(shoulders.Icon, ItemIconSizes.Small))) : null,
                    amulet != null ? new ItemViewModel(true, new ItemDetailViewModel(amulet, _api.ItemIconRepository.GetByIdAndSize(amulet.Icon, ItemIconSizes.Small))) : null,
                    chest != null ? new ItemViewModel(true, new ItemDetailViewModel(chest, _api.ItemIconRepository.GetByIdAndSize(chest.Icon, ItemIconSizes.Small))) : null,
                    bracers != null ? new ItemViewModel(true, new ItemDetailViewModel(bracers, _api.ItemIconRepository.GetByIdAndSize(bracers.Icon, ItemIconSizes.Small))) : null,
                    hands != null ? new ItemViewModel(true, new ItemDetailViewModel(hands, _api.ItemIconRepository.GetByIdAndSize(hands.Icon, ItemIconSizes.Small))) : null,
                    boots != null ? new ItemViewModel(true, new ItemDetailViewModel(boots, _api.ItemIconRepository.GetByIdAndSize(boots.Icon, ItemIconSizes.Small))) : null,
                    offHand != null ? new ItemViewModel(true, new ItemDetailViewModel(offHand, _api.ItemIconRepository.GetByIdAndSize(offHand.Icon, ItemIconSizes.Small))) : null,
                    rightRing != null ? new ItemViewModel(true, new ItemDetailViewModel(rightRing, _api.ItemIconRepository.GetByIdAndSize(rightRing.Icon, ItemIconSizes.Small))) : null,
                    waist != null ? new ItemViewModel(true, new ItemDetailViewModel(waist, _api.ItemIconRepository.GetByIdAndSize(waist.Icon, ItemIconSizes.Small))) : null,
                    leftRing != null ? new ItemViewModel(true, new ItemDetailViewModel(leftRing, _api.ItemIconRepository.GetByIdAndSize(leftRing.Icon, ItemIconSizes.Small))) : null,
                    mainHand != null ? new ItemViewModel(true, new ItemDetailViewModel(mainHand, _api.ItemIconRepository.GetByIdAndSize(mainHand.Icon, ItemIconSizes.Small))) : null,
                    pants != null ? new ItemViewModel(true, new ItemDetailViewModel(pants, _api.ItemIconRepository.GetByIdAndSize(pants.Icon, ItemIconSizes.Small))) : null,
                    hero, _manageContentViewModelActions));
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