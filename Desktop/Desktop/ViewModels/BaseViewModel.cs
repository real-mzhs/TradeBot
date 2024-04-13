using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels;

class BaseViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    public DelegateCommand DashboardCommand { get; set; }
    public DelegateCommand HistoryCommand { get; set; }
    public DelegateCommand TradeCommand { get; set; }
    public DelegateCommand WalletCommand { get; set; }
    public DelegateCommand ExitCommand { get; set; }

    public BaseViewModel(INavigationServices navigationServices)
    {

        _navigationServices = navigationServices;

        DashboardCommand = new DelegateCommand(
            () => 
            {
                _navigationServices.NavigateTo<DashboardViewModel>();
            });
        WalletCommand = new DelegateCommand(
            () => 
            {
                _navigationServices.NavigateTo<WalletViewModel>();
            });
        TradeCommand = new DelegateCommand(
            () =>
            {
                _navigationServices.NavigateTo<TradeViewModel>();
            });
        HistoryCommand = new DelegateCommand(
            () =>
            {
                _navigationServices.NavigateTo<HistoryViewModel>();
            });
        ExitCommand = new DelegateCommand(
            () =>
            {
                _navigationServices.NavigateTo<AuthViewModel>();
            });
    }
}
