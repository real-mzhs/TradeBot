using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.ViewModels.SmallViewModels;

class WalletDepositViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private string _cardNumber;
    private string _cardData;
    private string _cardSecretCode;

    public string CardNumber { 
        get => _cardNumber; 
        set => Set(ref _cardNumber, value); 
    }
    public string CardData 
    { 
        get => _cardData; 
        set => Set(ref _cardData, value); 
    }
    public string CardSecretCode { 
        get => _cardSecretCode; 
        set => Set(ref _cardSecretCode, value);
    }

    public DelegateCommand DepositCommand { get; set; }
    public DelegateCommand BackCommand { get; set; }



    public WalletDepositViewModel(INavigationServices navigationServices)
    {
        _navigationServices = navigationServices;

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
