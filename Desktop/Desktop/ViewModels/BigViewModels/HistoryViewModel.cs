using Desktop.Enums;
using Desktop.Messages.DataMessages;
using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LiveChartsCore.Measure;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace Desktop.ViewModels.BigViewModels;

public class HistoryViewModel : ViewModelBase
{
    private readonly IHistoryService _historyService;
    private readonly IMessenger _messenger;
    private User User { get; set; }
    public ObservableCollection<TradesHistory> TradesHistory { get; set; }
    public string Text { get; set; }
    public HistoryViewModel(IHistoryService historyService, IMessenger messenger )
    {
        _historyService = historyService;
        _messenger = messenger;

        _messenger.Register<UserDataMessage>(this, message => User = message.Data);

        //var HistoryResponse = _historyService.GetTradesHistory(user).GetAwaiter().GetResult();

        //TradesHistory = (ObservableCollection<TradesHistory>)HistoryResponse.Data.History;


        TradesHistory = new ObservableCollection<TradesHistory>()
        {
            new TradesHistory()
            {
                Id = "123",
                Amount = 123,
                EntryPrice = 123,
                ExitPrice = 321,
                Margin = 222,
                Quantity = 5,
                Type = PositionType.Buy
            }

        };

    }
}