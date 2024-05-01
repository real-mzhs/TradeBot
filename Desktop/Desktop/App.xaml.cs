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
using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop
{
    public partial class App : Application
    {

        public static SimpleInjector.Container Container { get; set; } = new SimpleInjector.Container();

        public void Register()
        {

            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<INavigationServices, NavigationService>();            
            Container.RegisterSingleton<TokenResponse>();

            Container.Register<ITradeClient, TradeClient>();
            Container.Register<IAuthenticationService, AuthenticationService>();
            Container.Register<IRegistrationService, RegistrationService>();
            Container.Register<IWalletService, WalletService>();
            Container.Register<IHistoryService, HistoryService>();
            Container.Register<ITradeService, TradeService>();
            Container.Register<IMarketService, MarketService>();

            Container.Register<MainViewModel>();
            Container.Register<DashboardViewModel>();
            Container.Register<HistoryViewModel>();
            Container.Register<TradeViewModel>();
            Container.Register<WalletViewModel>();
            Container.Register<AuthViewModel>();
            Container.Register<RegistrationViewModel>();
            Container.Register<BaseViewModel>();
            Container.Register<RecoveryViewModel>();
            Container.Register<WalletDepositViewModel>();
            Container.Register<WalletWidthdrawViewModel>();
            Container.Register<WalletContentViewModel>();
            Container.Register<TradeActionViewModel>();
            Container.Register<AIPanelViewModel>();
            Container.Register<SimplePanelViewModel>();




            //Container.Verify();
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
