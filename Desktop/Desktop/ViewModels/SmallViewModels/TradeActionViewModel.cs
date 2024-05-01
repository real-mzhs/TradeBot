using Desktop.Messages.NavigationMessages;
using Desktop.Services.Interfaces;
using Desktop.ViewModels.BigViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.SmallViewModels;

public class TradeActionViewModel : ViewModelBase
{
    public DelegateCommand AICommand { get; set; }
    public DelegateCommand WithoutAICommand { get; set; }


    private readonly INavigationServices _navigationServices;

    private ViewModelBase _currentView;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }

    public TradeActionViewModel(INavigationServices navigationServices, IMessenger _messenger)
    {
        _navigationServices = navigationServices;

        CurrentView = App.Container.GetInstance<DashboardViewModel>();
        _messenger.Register<MenuNavigationMessage>(this, message => CurrentView = message.ViewModelType);
    }
}
