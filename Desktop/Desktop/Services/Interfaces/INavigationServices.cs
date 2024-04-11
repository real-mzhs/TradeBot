using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

public interface INavigationServices
{
    public void NavigateTo<T>() where T : ViewModelBase;

}
