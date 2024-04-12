using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using Desktop.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace Desktop;

public partial class App : Application
{
    public static Container Container { get; set; } = new();

    public void Register()
    {
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<BotViewModel>();
        Container.RegisterSingleton<DashboardViewModel>();
        Container.RegisterSingleton<RegistrationViewModel>();
        Container.RegisterSingleton<LoginViewModel>();

        Container.RegisterSingleton<IBotService, BotService>();
        Container.RegisterSingleton<IHistoryService, HistoryService>();
        Container.RegisterSingleton<ILoginService, LoginService>();
        Container.RegisterSingleton<IRegistrationService, RegistrationService>();
        Container.RegisterSingleton<IWalletService, WalletService>();


    }

    protected override void OnStartup(StartupEventArgs e)
    {
        Register();

        var window = new MainView();

        window.DataContext = Container.GetInstance<MainViewModel>();

        window.ShowDialog();
    }
}