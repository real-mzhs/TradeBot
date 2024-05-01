using Desktop.Messages.NavigationMessages;
using Desktop.Services.Classes;
using Desktop.ViewModels.SmallViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Desktop.ViewModels.BigViewModels;

public class WalletViewModel : ViewModelBase
{   
    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set => Set(ref _currentView, value);
    }
    public WalletViewModel(IMessenger _messenger)
    {
        CurrentView = ServiceLocator.GetService<WalletContentViewModel>();
        _messenger.Register<WalletNavigationMessage>(this, message => CurrentView = message.ViewModelType);
    }
}
