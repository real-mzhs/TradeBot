using Desktop.Messages;
using Desktop.Services.Interfaces;
using Desktop.ViewModels.SmallViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.BigViewModels;

class BaseViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;

    public DelegateCommand DashboardCommand { get; set; }
    public DelegateCommand HistoryCommand { get; set; }
    public DelegateCommand TradeCommand { get; set; }
    public DelegateCommand WalletCommand { get; set; }
    public DelegateCommand ExitCommand { get; set; }



    private ViewModelBase _currentView;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }



    public BaseViewModel(INavigationServices navigationServices, IMessenger _messenger)
    {

        _navigationServices = navigationServices;

        CurrentView = App.Container.GetInstance<DashboardViewModel>();
        _messenger.Register<NavigationMessage>(this, message => CurrentView = message.ViewModelType);



        DashboardCommand = new DelegateCommand(
            () =>
            {
                CurrentView = App.Container.GetInstance<DashboardViewModel>();
            });
        WalletCommand = new DelegateCommand(
            () =>
            {
                CurrentView = App.Container.GetInstance<WalletViewModel>();

            });
        TradeCommand = new DelegateCommand(
            () =>
            {
                CurrentView = App.Container.GetInstance<TradeViewModel>();

            });
        HistoryCommand = new DelegateCommand(
            () =>
            {
                CurrentView = App.Container.GetInstance<HistoryViewModel>();

            });

        ExitCommand = new DelegateCommand(
            () =>
            {
                _navigationServices.NavigateTo<AuthViewModel>();
            });
    }
}
