using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using SimpleInjector;
using System.Windows;
using Desktop.ViewModels.BigViewModels;
using Desktop.ViewModels.SmallViewModels;
using Desktop.Views.BigViews;
using Desktop.Services.Network.API;

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
            Container.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            Container.RegisterSingleton<IRegistrationService, RegistrationService>();
            Container.RegisterSingleton<ITradeClient, TradeClient>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<DashboardViewModel>();
            Container.RegisterSingleton<HistoryViewModel>();
            Container.RegisterSingleton<TradeViewModel>();
            Container.RegisterSingleton<WalletViewModel>();
            Container.RegisterSingleton<AuthViewModel>();
            Container.RegisterSingleton<RegistrationViewModel>();
            Container.RegisterSingleton<BaseViewModel>();
            Container.RegisterSingleton<RecoveryViewModel>();
            Container.RegisterSingleton<WalletDepositViewModel>();
            Container.RegisterSingleton<WalletWidthdrawViewModel>();
            Container.RegisterSingleton<WalletContentViewModel>();






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
