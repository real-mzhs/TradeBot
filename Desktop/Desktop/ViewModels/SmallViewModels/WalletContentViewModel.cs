using Desktop.Messages.DataMessages;
using Desktop.Models.MainModels;
using Desktop.Models.PresentationModels;
using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using Desktop.Services.Network.Responses;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;

namespace Desktop.ViewModels.SmallViewModels;

public class WalletContentViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationServices;
    private readonly IMessenger _messenger;
    private readonly IWalletService _walletService;
    private User User { get; set; }

    private Wallet _wallet;
    public DelegateCommand WidthdrawCommand { get; set; }
    public DelegateCommand DepositCommand { get; set; }
    public DataResponse<WalletResponse> Response { get; set; }

    public ObservableCollection<Transaction> Transactions
    {
        get => _wallet.Transactions;
        set
        {
            if (_wallet.Transactions != value)
            {
                _wallet.Transactions = value;
                RaisePropertyChanged(nameof(Transactions));
            }
        }
    }
    public decimal Balance
    {
        get => _wallet.Balance;
        set
        {
            if (_wallet.Balance != value)
            {
                _wallet.Balance = (int)value;
                RaisePropertyChanged(nameof(Balance));
            }
        }
    }

    public WalletContentViewModel(INavigationServices navigationServices, IWalletService walletService, IMessenger messenger)
    {
        _navigationServices = navigationServices;
        _messenger = messenger;
        _walletService = walletService;

        _messenger.Register<UserDataMessage>(this, message => User = message.Data);


        //try
        //{
        //    Response = _walletService.GetWalletDataAsync(User).GetAwaiter().GetResult();
        //    Transactions = Response.Data.transactions;
        //    Balance = Response.Data.balance;

        //}
        //catch (Exception ex) 
        //{
        //    MessageBox.Show($"Status code - {Response.StatusCode}: {ex.Message}");
        //}


        WidthdrawCommand = new DelegateCommand(
          () =>
          {
              _messenger.Send(new WalletDataMessage(){ Data = _wallet });
              _navigationServices.WalletNavigateTo<WalletWidthdrawViewModel>();
          });
        DepositCommand = new DelegateCommand(
          () =>
          {
              _messenger.Send(new WalletDataMessage() { Data = _wallet });
              _navigationServices.WalletNavigateTo<WalletDepositViewModel>();
          });
        
    }

}
