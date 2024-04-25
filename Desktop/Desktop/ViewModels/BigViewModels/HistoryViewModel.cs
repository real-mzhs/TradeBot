using Desktop.Enums;
using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using LiveChartsCore.Measure;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;

namespace Desktop.ViewModels.BigViewModels;

public class HistoryViewModel : ViewModelBase
{
    private readonly IHistoryService _historyService;
    public ObservableCollection<TradesHistory> TradesHistory { get; set; }
    public string Text { get; set; }
    public HistoryViewModel(IHistoryService historyService, User user)
    {
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



        //_historyService = historyService;
        //var HistoryResponse = _historyService.GetTradesHistory(user).GetAwaiter().GetResult();

        //TradesHistory = (ObservableCollection<TradesHistory>)HistoryResponse.Data.History;
    }
}