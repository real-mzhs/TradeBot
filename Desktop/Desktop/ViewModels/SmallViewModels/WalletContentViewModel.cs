using Desktop.Messages;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.SmallViewModels
{
    class WalletContentViewModel : ViewModelBase
    {
        private readonly INavigationServices _navigationServices;
        private readonly IMessenger _messenger;
        public DelegateCommand WidthdrawCommand { get; set; }
        public DelegateCommand DepositCommand { get; set; }
      

        public WalletContentViewModel(INavigationServices navigationServices, IMessenger _messenger)
        {

            _navigationServices = navigationServices;

            WidthdrawCommand = new DelegateCommand(
              () =>
              {
                  _navigationServices.WalletNavigateTo<WalletWidthdrawViewModel>();
              });
            DepositCommand = new DelegateCommand(
              () =>
              {
                  _navigationServices.WalletNavigateTo<WalletDepositViewModel>();
              });

        }

    }
}
