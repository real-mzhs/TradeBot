using Desktop.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels;

class HistoryViewModel : ViewModelBase
{
    private ObservableCollection<TradesHistory> _history;
    public ObservableCollection<TradesHistory> History
    {
        get { return _history; }
        set { Set(ref _history, value); }
    }
}
