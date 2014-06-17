using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI.SampleData
{
    public class LoadDataViewModelSampleData : ILoadDataViewModel
    {

        public LoadDataViewModelSampleData()
        {
            Name = "Load Profile data mock";
            var api = new ApiAccessFacade(CollectMode.Offline, Locales.en_GB, null, new TimeSpan(0,1,0,0));
            LoadProfileCommand = new LoadProfileCommand(api) {LoadDataViewModel = this};

            LoadHeroCommand = new LoadHeroCommand(api, new ManageContentViewModelActions(
                (o) => { ; }, (o) => { ; })) { LoadDataViewModel = this };
        }

        public string Name { get; private set; }
        public bool IsLoading { get; set; }

        public ICommand Delete
        {
            get { return null; }
        }

        public ObservableCollection<Hero> Heroes { get; set; }
        public string Battletag { get; set; }
        public int HeroId { get; set; }
        public LoadHeroCommand LoadHeroCommand { get; private set; }
        public ILoadProfileCommand LoadProfileCommand { get; private set; }
    }
}
