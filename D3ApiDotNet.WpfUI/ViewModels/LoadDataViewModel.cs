using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.WpfUI.Annotations;
using D3ApiDotNet.WpfUI.Commands;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public class LoadDataViewModel : ILoadDataViewModel
    {

        public LoadDataViewModel([NotNull] IAddContentViewModelCommand addContentViewModelCommand,
            [NotNull] ApiAccessFacade api)
        {
            if (addContentViewModelCommand == null) throw new ArgumentNullException("addContentViewModelCommand");
            if (api == null) throw new ArgumentNullException("api");
            LoadProfileCommand = new LoadProfileCommand(api,this);
            LoadHeroCommand = new LoadHeroCommand(api,this,addContentViewModelCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Hero> Heroes { get; set; }
        public string Battletag { get; set; }
        public string HeroId { get; set; }
        public LoadHeroCommand LoadHeroCommand { get; private set; }
        public ILoadProfileCommand LoadProfileCommand { get; private set; }

        public string Name
        {
            get { return "Load Profile data"; }
        }
    }
}