using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class LoadHeroCommand : ICommand
    {
        private readonly ApiAccessFacade _api;
        private readonly ILoadDataViewModel _loadDataViewModel;
        private readonly IAddContentViewModelCommand _addContentViewModelCommand;

        public LoadHeroCommand([NotNull] ApiAccessFacade api, [NotNull] ILoadDataViewModel loadDataViewModel,
            [NotNull] IAddContentViewModelCommand addContentViewModelCommand)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (loadDataViewModel == null) throw new ArgumentNullException("loadDataViewModel");
            if (addContentViewModelCommand == null) throw new ArgumentNullException("addContentViewModelCommand");
            _api = api;
            _loadDataViewModel = loadDataViewModel;
            _addContentViewModelCommand = addContentViewModelCommand;
            
        }

        public bool CanExecute(object parameter)
        {
            if (_loadDataViewModel.Heroes == null)
                return false;
            return _loadDataViewModel.Heroes.Count > _loadDataViewModel.HeroId;
        }

        public async void Execute(object parameter)
        {
            var hero =
                _loadDataViewModel.Heroes[_loadDataViewModel.HeroId];
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

            _addContentViewModelCommand.AddContentViewModel(
                new HeroViewModel(
                    head != null ? new ItemViewModel(true, new ItemDetailViewModel(head,_api.ItemIconRepository.GetByIdAndSize(head.Icon))) : null,
                    shoulders != null ? new ItemViewModel(true, new ItemDetailViewModel(shoulders,_api.ItemIconRepository.GetByIdAndSize(shoulders.Icon))) : null,
                    amulet != null ? new ItemViewModel(true, new ItemDetailViewModel(amulet, _api.ItemIconRepository.GetByIdAndSize(amulet.Icon))) : null,
                    chest != null ? new ItemViewModel(true, new ItemDetailViewModel(chest, _api.ItemIconRepository.GetByIdAndSize(chest.Icon))) : null,
                    bracers != null ? new ItemViewModel(true, new ItemDetailViewModel(bracers, _api.ItemIconRepository.GetByIdAndSize(bracers.Icon))) : null,
                    hands != null ? new ItemViewModel(true, new ItemDetailViewModel(hands, _api.ItemIconRepository.GetByIdAndSize(hands.Icon))) : null,
                    boots != null ? new ItemViewModel(true, new ItemDetailViewModel(boots, _api.ItemIconRepository.GetByIdAndSize(boots.Icon))) : null,
                    offHand != null ? new ItemViewModel(true, new ItemDetailViewModel(offHand, _api.ItemIconRepository.GetByIdAndSize(offHand.Icon))) : null,
                    rightRing != null ? new ItemViewModel(true, new ItemDetailViewModel(rightRing, _api.ItemIconRepository.GetByIdAndSize(rightRing.Icon))) : null,
                    waist != null ? new ItemViewModel(true, new ItemDetailViewModel(waist, _api.ItemIconRepository.GetByIdAndSize(waist.Icon))) : null,
                    leftRing != null ? new ItemViewModel(true, new ItemDetailViewModel(leftRing, _api.ItemIconRepository.GetByIdAndSize(leftRing.Icon))) : null,
                    mainHand != null ? new ItemViewModel(true, new ItemDetailViewModel(mainHand, _api.ItemIconRepository.GetByIdAndSize(mainHand.Icon))) : null,
                    pants != null ? new ItemViewModel(true, new ItemDetailViewModel(pants, _api.ItemIconRepository.GetByIdAndSize(pants.Icon))) : null,
                    hero));
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