using System;
using System.Globalization;
using System.Threading.Tasks;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.ViewModels;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.Commands
{
    public class LoadProfileCommand : ILoadProfileCommand
    {
        private readonly ApiAccessFacade _api;

        public LoadProfileCommand([NotNull] ApiAccessFacade api)
        {
            if (api == null) throw new ArgumentNullException("api");
            _api = api;
        }

        public ILoadDataViewModel LoadDataViewModel { get; set; }

        public bool CanExecute(object parameter)
        {
            return LoadDataViewModel.Battletag != null;
        }

        public async void Execute(object parameter)
        {
            var battletag = LoadDataViewModel.Battletag;
            var profile = await Task.Factory.StartNew(() => _api.ProfileRepository.GetByBattletag(battletag));
            LoadDataViewModel.Heroes.Clear();
            if (profile.IsErrorObject())
                return;
            foreach (var hero in profile.Heroes)
            {
                var herodata = await Task.Factory.StartNew(() => _api.HeroRepository.GetByBattletagAndId(battletag, hero.Id.ToString()));
                LoadDataViewModel.Heroes.Add(herodata);
                LoadDataViewModel.LoadHeroCommand.OnCanExecuteChanged();
            }
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