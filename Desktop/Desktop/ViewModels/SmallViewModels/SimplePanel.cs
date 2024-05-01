using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.SmallViewModels;

public class SimplePanel : ViewModelBase
{
    public string _buyThreshold;
    public string BuyThreshold
    {
        get => _buyThreshold;
        set
        {
            Set(ref _buyThreshold, value);
        }
    }
    public string _sellThreshold;
    public string SellThreshold
    {
        get => _sellThreshold;
        set
        {
            Set(ref _sellThreshold, value);
        }
    }
    public string _amount;
    public string Amount
    {
        get => _amount;
        set
        {
            Set(ref _amount, value);
        }
    }

    public DelegateCommand StartCommand { get; set; }
}
