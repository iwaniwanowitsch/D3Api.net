using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.Core.Objects.Item;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.DataAccess.Repositories;
using D3ApiDotNet.DataAccess.WebInteraction;
using D3ApiDotNet.WpfUI.Commands;
using D3ApiDotNet.WpfUI.ViewModels;
using System.Net;
using D3ApiDotNet.WpfUI.ViewModels.Interfaces;

namespace D3ApiDotNet.WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindowViewModel = new MainWindowViewModel(new ObservableCollection<IContentViewModel>());

            var collectMode = CollectMode.TryCacheThenOnline;
            var locale = Locales.en_GB;

            var api = new ApiAccessFacade(collectMode, locale, null /*new WebProxy("127.0.0.1:3128")*/, new TimeSpan(0, 1, 0, 0));
            var longapi = new ApiAccessFacade(collectMode, locale, null /*new WebProxy("127.0.0.1:3128")*/, TimeSpan.MaxValue);
            var itemCollector = new ItemNamesCollector(new StreamWebRepository(null));

            var manageContentViewModelCommand =
                new ManageContentViewModelActions(mainWindowViewModel.AddContentViewModel,
                    mainWindowViewModel.RemoveContentViewModel);
            var loadProfileCommand = new LoadProfileCommand(api);
            var loadHeroCommand = new LoadHeroCommand(api, manageContentViewModelCommand);

            var heroes = new ObservableCollection<Hero>();

            var loadDataViewModel = new LoadDataViewModel(api, loadProfileCommand, loadHeroCommand, heroes, manageContentViewModelCommand);

            var allItemListViewModel = new AllItemListViewModel(longapi, itemCollector, new ObservableCollection<Item>(),
                manageContentViewModelCommand);

            loadProfileCommand.LoadDataViewModel = loadDataViewModel;
            loadHeroCommand.LoadDataViewModel = loadDataViewModel;

            mainWindowViewModel.AddContentViewModel(loadDataViewModel);
            mainWindowViewModel.AddContentViewModel(allItemListViewModel);

            var mainWindow = new MainWindow { DataContext = mainWindowViewModel };

            MainWindow = mainWindow;
            MainWindow.Show();
        }
    }
}
