using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Windows;

namespace Desktop.ViewModels.SmallViewModels;

class WalletWidthdrawViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private string _cardNumber;
    public string CardNumber 
    { 
        get => _cardNumber; 
        set => Set(ref _cardNumber, value); 
    }

    private Wallet _wallet;
    public Wallet Wallet
    {
        get => _wallet;
        set
        {
            Set(ref _wallet, value);
        }
    }

    public DelegateCommand WidthdrawCommand { get; set; }
    public DelegateCommand BackCommand { get; set; }


    public WalletWidthdrawViewModel(INavigationServices navigationServices)
    {
        _navigationServices = navigationServices;
        WidthdrawCommand = new DelegateCommand(
          () =>
          {
              MessageBox.Show(CardNumber);
          });
        BackCommand = new DelegateCommand(
         () =>
         {
             _navigationServices.WalletNavigateTo<WalletContentViewModel>();
         });
    }
}
