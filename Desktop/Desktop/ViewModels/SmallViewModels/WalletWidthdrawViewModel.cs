using Desktop.Messages.DataMessages;
using Desktop.Models.MainModels;
using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System.Windows;

namespace Desktop.ViewModels.SmallViewModels;

class WalletWidthdrawViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private readonly IMessenger _messenger;
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


    public WalletWidthdrawViewModel(INavigationServices navigationServices, IMessenger messenger)
    {
        _navigationServices = navigationServices;
        _messenger = messenger;

        _messenger.Register<WalletDataMessage>(this, message => Wallet = message.Data);

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
