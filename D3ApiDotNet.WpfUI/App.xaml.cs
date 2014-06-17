using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using D3ApiDotNet.Core.Objects.Hero;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
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

            var api = new ApiAccessFacade(CollectMode.TryCacheThenOnline, Locales.en_GB, null /*new WebProxy("127.0.0.1:3128")*/, new TimeSpan(0, 1, 0, 0));

            var manageContentViewModelCommand =
                new ManageContentViewModelActions(mainWindowViewModel.AddContentViewModel,
                    mainWindowViewModel.RemoveContentViewModel);
            var loadProfileCommand = new LoadProfileCommand(api);
            var loadHeroCommand = new LoadHeroCommand(api, manageContentViewModelCommand);

            var heroes = new ObservableCollection<Hero>();

            var loadDataViewModel = new LoadDataViewModel(api, loadProfileCommand, loadHeroCommand, heroes, manageContentViewModelCommand);

            loadProfileCommand.LoadDataViewModel = loadDataViewModel;
            loadHeroCommand.LoadDataViewModel = loadDataViewModel;

            mainWindowViewModel.AddContentViewModel(loadDataViewModel);

            var mainWindow = new MainWindow { DataContext = mainWindowViewModel };

            MainWindow = mainWindow;
            MainWindow.Show();
        }
    }
}
