using System;
using System.Globalization;
using System.Threading.Tasks;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class LoadProfileCommand : ILoadProfileCommand
    {
        private readonly ApiAccessFacade _api;
        private readonly ILoadDataViewModel _loadDataViewModel;

        public LoadProfileCommand([NotNull] ApiAccessFacade api, [NotNull] ILoadDataViewModel loadDataViewModel)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (loadDataViewModel == null) throw new ArgumentNullException("loadDataViewModel");
            _api = api;
            _loadDataViewModel = loadDataViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _loadDataViewModel.Battletag != null;
        }

        public async void Execute(object parameter)
        {
            var battletag = _loadDataViewModel.Battletag;
            var profile = await Task.Factory.StartNew(() => _api.ProfileRepository.GetByBattletag(battletag));
            foreach (var hero in profile.Heroes)
                await
                    Task.Factory.StartNew(() =>
                        _loadDataViewModel.Heroes.Add(_api.HeroRepository.GetByBattletagAndId(battletag,
                            hero.Id.ToString(CultureInfo.InvariantCulture))));
        }

        public event EventHandler CanExecuteChanged;
    }
}