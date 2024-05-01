using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Desktop.Services.Interfaces;
using Desktop.Messages.NavigationMessages;

namespace Desktop.Services.Classes;

public class NavigationService(IMessenger messenger) : INavigationServices
{
    public void NavigateTo<T>() where T : ViewModelBase
    {
        messenger.Send(new NavigationMessage
            {
                ViewModelType = ServiceLocator.GetService<T>()
            }
        );
    }

    public void MenuNavigateTo<T>() where T : ViewModelBase
    {
        messenger.Send(new MenuNavigationMessage
            {
                ViewModelType = ServiceLocator.GetService<T>()
            }
        );
    }

    public void WalletNavigateTo<T>() where T : ViewModelBase
    {
        messenger.Send(new WalletNavigationMessage
            {
                ViewModelType = ServiceLocator.GetService<T>()
            }
        );
    }
}