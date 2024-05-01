using System.IO;
using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.API;
using Desktop.ViewModels.BigViewModels;
using Desktop.ViewModels.SmallViewModels;
using Desktop.Views.BigViews;
using Desktop.Views.SmallViews;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Desktop;

public class Startup
{
    public IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json",
                    optional: true,
                    reloadOnChange: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IMessenger, Messenger>();
                services.AddSingleton<INavigationServices, NavigationService>();

                services.AddScoped<IAuthenticationService, AuthenticationService>();
                services.AddScoped<IRegistrationService, RegistrationService>();
                services.AddScoped<IHistoryService, HistoryService>();
                services.AddScoped<IMarketService, MarketService>();
                services.AddScoped<ITradeService, TradeService>();
                services.AddScoped<IWalletService, WalletService>();
                services.AddScoped<ITradeClient, TradeClient>();

                services.AddTransient<MainView>();
                services.AddTransient<MainViewModel>();

                services.AddTransient<AuthView>();
                services.AddTransient<AuthViewModel>();

                services.AddTransient<BaseView>();
                services.AddTransient<BaseViewModel>();

                services.AddTransient<DashboardView>();
                services.AddTransient<DashboardViewModel>();

                services.AddTransient<HistoryView>();
                services.AddTransient<HistoryViewModel>();

                services.AddTransient<RecoveryView>();
                services.AddTransient<RecoveryViewModel>();

                services.AddTransient<RecoveryView>();
                services.AddTransient<RegistrationViewModel>();

                services.AddTransient<TradeView>();
                services.AddTransient<TradeViewModel>();

                services.AddTransient<WalletView>();
                services.AddTransient<WalletViewModel>();

                services.AddTransient<WalletContentView>();
                services.AddTransient<WalletContentViewModel>();

                services.AddTransient<WalletDepositView>();
                services.AddTransient<WalletDepositViewModel>();

                services.AddTransient<WalletWidthdrawView>();
                services.AddTransient<WalletWidthdrawViewModel>();
            });
}