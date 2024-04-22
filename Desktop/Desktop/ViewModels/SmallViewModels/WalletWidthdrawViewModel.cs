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

class WalletWidthdrawViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private string _cardNumber;
    public string CardNumber { get => _cardNumber; set => Set(ref _cardNumber, value); }

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
