using Desktop.Enums;
using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Desktop.ViewModels.BigViewModels;

public class HistoryViewModel : ViewModelBase
{
    private readonly IHistoryService _historyService;
    public ObservableCollection<TradesHistory> TradesHistory { get; set; }
    public string Text { get; set; }
    public HistoryViewModel(IHistoryService historyService, User user)
    {
        //_historyService = historyService;
        //var HistoryResponse = _historyService.GetTradesHistory(user).GetAwaiter().GetResult();

        //TradesHistory = (ObservableCollection<TradesHistory>)HistoryResponse.Data.History;

    }
}