using GalaSoft.MvvmLight;

namespace Desktop.Services.Interfaces;

public interface INavigationServices
{
    public void NavigateTo<T>() where T : ViewModelBase;
    public void MenuNavigateTo<T>() where T : ViewModelBase;
    public void WalletNavigateTo<T>() where T : ViewModelBase;

}
