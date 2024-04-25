using Desktop.Messages.DataMessages;
using Desktop.Messages.NavigationMessages;
using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System.Windows;

namespace Desktop.ViewModels.SmallViewModels;

public class WalletDepositViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private readonly IMessenger _messenger;

    private Wallet _wallet;
    public Wallet Wallet
    {
        get => _wallet;
        set
        {
            Set(ref _wallet, value);
        }
    }

    private string _cardNumber;
    public string CardNumber 
    { 
        get => _cardNumber; 
        set => Set(ref _cardNumber, value); 
    }

    private string _cardData;
    public string CardData 
    { 
        get => _cardData; 
        set => Set(ref _cardData, value); 
    }

    private string _cardSecretCode;
    public string CardSecretCode
    { 
        get => _cardSecretCode; 
        set => Set(ref _cardSecretCode, value);
    }

    public DelegateCommand DepositCommand { get; set; }
    public DelegateCommand BackCommand { get; set; }



    public WalletDepositViewModel(INavigationServices navigationServices, IMessenger messenger)
    {
        _navigationServices = navigationServices;
        _messenger = messenger;

        _messenger.Register<WalletDataMessage>(this, message => Wallet = message.Data);

        DepositCommand = new DelegateCommand(
         () =>
         {
             MessageBox.Show(CardNumber);
             MessageBox.Show(CardData);
             MessageBox.Show(CardSecretCode);
         });
        BackCommand = new DelegateCommand(
         () =>
         {
             _navigationServices.WalletNavigateTo<WalletContentViewModel>();
         });


    }

}
