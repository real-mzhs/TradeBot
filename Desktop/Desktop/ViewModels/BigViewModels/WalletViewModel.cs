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

public class WalletViewModel : ViewModelBase
{

    private readonly INavigationServices _navigationServices;
    private readonly IMessenger _messenger;


    public DelegateCommand WidthdrawCommand { get; set; }
    public DelegateCommand DepositCommand { get; set; }

    private ViewModelBase _currentView;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }

    public WalletViewModel(INavigationServices navigationServices, IMessenger _messenger)
    {
        _navigationServices = navigationServices;

        CurrentView = App.Container.GetInstance<WalletContentViewModel>();
        _messenger.Register<WalletNavigationMessage>(this, message => CurrentView = message.ViewModelType);
    }




}
