using Desktop.Services.Classes;
using System.Windows;
using Desktop.ViewModels.BigViewModels;
using Desktop.Views.BigViews;
using Microsoft.Extensions.Hosting;

namespace Desktop;

public partial class App
{
    private static IHost? AppHost { get; set; }

    public App()
    {
        var startup = new Startup();
        AppHost = startup.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        ServiceLocator.Initialize(AppHost);

        var mainWindow = new MainView
        {
            DataContext = ServiceLocator.GetService<MainViewModel>()
        };

        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}