using Desktop.Messages;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels;

public class MainViewModel : ViewModelBase
{

    private ViewModelBase _currentView;
    private readonly IMessenger _messenger;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }




    public DelegateCommand HistoryCommand { get; set; }
    public DelegateCommand DashboardCommand { get; set; }
    public DelegateCommand ChartCommand { get; set; }
    public DelegateCommand WalletCommand { get; set; }






    public MainViewModel(IMessenger messenger)
    {

        _messenger = messenger;
        CurrentView = App.Container.GetInstance<DashboardViewModel>();

        _messenger.Register<NavigationMessage>(this, message => CurrentView = message.ViewModelType);



        DashboardCommand = new(() =>
        {
            CurrentView = App.Container.GetInstance<DashboardViewModel>();
        });

        HistoryCommand = new(() =>
        {
            CurrentView = App.Container.GetInstance<HistoryViewModel>();
        });

        ChartCommand = new(() =>
        {
            CurrentView = App.Container.GetInstance<ChartViewModel>();
        });

        WalletCommand = new(() =>
        {
            CurrentView = App.Container.GetInstance<WalletViewModel>();
        });



    }
}
