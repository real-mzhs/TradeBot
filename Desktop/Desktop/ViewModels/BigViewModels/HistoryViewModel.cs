using Desktop.Enums;
using Desktop.Models.MainModels;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.BigViewModels;

public class HistoryViewModel : ViewModelBase
{
public TradesHistory TradesHistory { get; set; }
    public string Text { get; set; }   
    public HistoryViewModel()
    {
        Text = "kakoyto text";
        TradesHistory = new TradesHistory();
        TradesHistory.Coin = new() { Name = "BTC" };
        TradesHistory.Amount = 0;
        TradesHistory.EntryPrice = 0;
        TradesHistory.EntryPrice = 0;
        TradesHistory.Margin = 0;
        TradesHistory.Quantity = 0;
        TradesHistory.Type = PositionType.Buy;

    }
}