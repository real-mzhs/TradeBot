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
    private string _cardNumber;
    public string CardNumber { get => _cardNumber; set => Set(ref _cardNumber, value); }

    public DelegateCommand WidthdrawCommand { get; set; }


    public WalletWidthdrawViewModel()
    {

        WidthdrawCommand = new DelegateCommand(
          () =>
          {
              MessageBox.Show(CardNumber);
          });
    }
}
