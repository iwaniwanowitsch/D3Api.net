using System.Collections.ObjectModel;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.WpfUI.Commands;

namespace D3ApiDotNet.WpfUI.ViewModels
{
    public interface ILoadDataViewModel : IContentViewModel
    {
        ObservableCollection<Hero> Heroes { get; set; }

        string Battletag { get; set; }

        int HeroId { get; set; }

        LoadHeroCommand LoadHeroCommand { get; }

        ILoadProfileCommand LoadProfileCommand { get; }
    }
}
