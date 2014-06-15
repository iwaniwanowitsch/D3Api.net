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
            return _loadDataViewModel.Heroes.FirstOrDefault(
                    o => o.Id.ToString(CultureInfo.InvariantCulture) == _loadDataViewModel.HeroId) != null;
        }

        public async void Execute(object parameter)
        {
            var hero =
                _loadDataViewModel.Heroes.FirstOrDefault(
                    o => o.Id.ToString(CultureInfo.InvariantCulture) == _loadDataViewModel.HeroId);
            if (hero == null)
                return;
            var items = hero.Items;
            var head = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Head.TooltipParams));
            var shoulders = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Shoulders.TooltipParams));
            var amulet = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Neck.TooltipParams));
            var hands = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Hands.TooltipParams));
            var chest = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Torso.TooltipParams));
            var bracers = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Bracers.TooltipParams));
            var leftRing = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.LeftFinger.TooltipParams));
            var waist = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Waist.TooltipParams));
            var rightRing = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.RightFinger.TooltipParams));
            var mainHand = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.MainHand.TooltipParams));
            var pants = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Legs.TooltipParams));
            var offHand = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.OffHand.TooltipParams));
            var boots = await Task.Factory.StartNew(() => _api.ItemRepository.GetByTooltipParams(items.Feet.TooltipParams));

            _addContentViewModelCommand.AddContentViewModel(
                new HeroViewModel(
                    new ItemViewModel(true, new ItemDetailViewModel(head,_api.ItemIconRepository.GetByIdAndSize(head.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(shoulders,_api.ItemIconRepository.GetByIdAndSize(shoulders.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(amulet, _api.ItemIconRepository.GetByIdAndSize(amulet.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(chest, _api.ItemIconRepository.GetByIdAndSize(chest.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(bracers, _api.ItemIconRepository.GetByIdAndSize(bracers.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(hands, _api.ItemIconRepository.GetByIdAndSize(hands.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(boots, _api.ItemIconRepository.GetByIdAndSize(boots.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(offHand, _api.ItemIconRepository.GetByIdAndSize(offHand.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(rightRing, _api.ItemIconRepository.GetByIdAndSize(rightRing.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(waist, _api.ItemIconRepository.GetByIdAndSize(waist.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(leftRing, _api.ItemIconRepository.GetByIdAndSize(leftRing.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(mainHand, _api.ItemIconRepository.GetByIdAndSize(mainHand.Icon))),
                    new ItemViewModel(true, new ItemDetailViewModel(pants, _api.ItemIconRepository.GetByIdAndSize(pants.Icon))),
                    hero));
        }

        public event EventHandler CanExecuteChanged;
    }
}