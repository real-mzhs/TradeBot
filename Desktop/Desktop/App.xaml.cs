using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using Desktop.ViewModels;
using Desktop.Views;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static SimpleInjector.Container Container { get; set; } = new SimpleInjector.Container();

        public void Register()
        {

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationServices, NavigationService>();
            Container.RegisterSingleton<IDataService, DataService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<DashboardViewModel>();
            Container.RegisterSingleton<HistoryViewModel>();
            Container.RegisterSingleton<ChartViewModel>();
            Container.RegisterSingleton<WalletViewModel>();



            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = new MainView();

            window.DataContext = Container.GetInstance<MainViewModel>();

            window.ShowDialog();
        }
    }
}
