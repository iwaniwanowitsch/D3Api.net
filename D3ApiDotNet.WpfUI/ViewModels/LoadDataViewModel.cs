using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class LoadDataViewModel : ILoadDataViewModel
    {
        private string _battletag;
        private ObservableCollection<Hero> _heroes;
        private int _heroId;

        public LoadDataViewModel([NotNull] IAddContentViewModelCommand addContentViewModelCommand,
            [NotNull] ApiAccessFacade api)
        {
            if (addContentViewModelCommand == null) throw new ArgumentNullException("addContentViewModelCommand");
            if (api == null) throw new ArgumentNullException("api");
            LoadProfileCommand = new LoadProfileCommand(api,this);
            LoadHeroCommand = new LoadHeroCommand(api,this,addContentViewModelCommand);
            Heroes = new ObservableCollection<Hero>();
        }

        public ObservableCollection<Hero> Heroes
        {
            get { return _heroes; }
            set
            {
                if (value == null) return;
                _heroes = value;
                LoadHeroCommand.OnCanExecuteChanged();
            }
        }

        public string Battletag
        {
            get { return _battletag; }
            set
            {
                if (value == null) return;
                _battletag = value;
                LoadProfileCommand.OnCanExecuteChanged();
            }
        }

        public int HeroId
        {
            get { return _heroId; }
            set
            {
                _heroId = value;
                LoadHeroCommand.OnCanExecuteChanged();
            }
        }

        public LoadHeroCommand LoadHeroCommand { get; private set; }
        public ILoadProfileCommand LoadProfileCommand { get; private set; }

        public string Name
        {
            get { return "Load Profile data"; }
        }
    }
}