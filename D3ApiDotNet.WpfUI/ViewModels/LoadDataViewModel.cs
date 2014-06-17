using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class LoadDataViewModel : BaseContentViewModel, ILoadDataViewModel
    {
        private string _battletag;
        private ObservableCollection<Hero> _heroes;
        private int _heroId;

        public LoadDataViewModel([NotNull] ApiAccessFacade api, [NotNull] LoadProfileCommand loadProfileCommand,
            [NotNull] LoadHeroCommand loadHeroCommand, [NotNull] ObservableCollection<Hero> heroes,
            [NotNull] IManageContentViewModelActions manageContentViewModelActions)
            : base(manageContentViewModelActions, false)
        {
            if (api == null) throw new ArgumentNullException("api");
            if (loadProfileCommand == null) throw new ArgumentNullException("loadProfileCommand");
            if (loadHeroCommand == null) throw new ArgumentNullException("loadHeroCommand");
            if (heroes == null) throw new ArgumentNullException("heroes");
            LoadProfileCommand = loadProfileCommand;
            LoadHeroCommand = loadHeroCommand;
            _heroes = heroes;
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

        public override string Name
        {
            get { return "Load Profile data"; }
        }
    }
}