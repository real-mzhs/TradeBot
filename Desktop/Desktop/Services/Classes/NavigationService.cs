using Desktop.Messages;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Desktop.Services.Interfaces;
using Desktop.Messages.NavigationMessages;

namespace Desktop.Services.Classes;

public class NavigationService : INavigationServices
{
    private readonly IMessenger _messenger;
    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }


    public void NavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new NavigationMessage()
        {
            ViewModelType = App.Container.GetInstance<T>() 
        }
        );
    }
    public void MenuNavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new MenuNavigationMessage()
        {
            ViewModelType = App.Container.GetInstance<T>() 
        }
        );
    }
    public void WalletNavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new WalletNavigationMessage()
        {
            ViewModelType = App.Container.GetInstance<T>()
        }
        );
    }

}
