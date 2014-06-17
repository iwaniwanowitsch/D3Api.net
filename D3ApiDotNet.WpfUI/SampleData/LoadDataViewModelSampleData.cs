using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadHeroCommand = new LoadHeroCommand(api, this, new AddContentViewModelCommand(
                (o) => { ; }));
            LoadProfileCommand = new LoadProfileCommand(api, this);
        }

        public string Name { get; private set; }
        public ObservableCollection<Hero> Heroes { get; set; }
        public string Battletag { get; set; }
        public int HeroId { get; set; }
        public LoadHeroCommand LoadHeroCommand { get; private set; }
        public ILoadProfileCommand LoadProfileCommand { get; private set; }
    }
}
