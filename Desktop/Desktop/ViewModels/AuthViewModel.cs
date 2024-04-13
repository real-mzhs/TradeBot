using Desktop.Models;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels;
class AuthViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationService;
    private readonly ILoginService _loginService;
    public User CurrentUser { get; set; }
    public string Email
    {
        get { return CurrentUser.Email; }
        set { CurrentUser.Email = value; }
    }
    public string Password
    {
        get { return CurrentUser.PasswordHash; }
        set { CurrentUser.PasswordHash = value; }
    }
    public DelegateCommand LoginCommand { get; set; }

    public AuthViewModel(INavigationServices navigationService, ILoginService loginService)
    {
        _navigationService = navigationService;
        _loginService = loginService;

    }
}
