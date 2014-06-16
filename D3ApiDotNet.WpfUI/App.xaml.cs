using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using D3ApiDotNet.DataAccess;
using D3ApiDotNet.DataAccess.API;
using D3ApiDotNet.WpfUI.ViewModels;
using System.Net;

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

            var api = new ApiAccessFacade(CollectMode.TryCacheThenOnline, Locales.en_GB, null/*new WebProxy("127.0.0.1:3128")*/);

            var loadDataViewModel = new LoadDataViewModel(mainWindowViewModel, api);

            mainWindowViewModel.AddContentViewModel(loadDataViewModel);

            var mainWindow = new MainWindow { DataContext = mainWindowViewModel };

            MainWindow = mainWindow;
            MainWindow.Show();
        }
    }
}
