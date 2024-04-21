using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Desktop.Models.MainModels;

namespace Desktop.ViewModels;
class AuthViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationService;
    private readonly IAuthenticationService _AuthService;
    public User CurrentUser { get; set; } = new();
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
    public DelegateCommand RegisrationCommand { get; set; }
    public DelegateCommand ForgotPasswordCommand { get; set; }

    public AuthViewModel(INavigationServices navigationService, IAuthenticationService AuthService)
    {
        
        _navigationService = navigationService;
        _AuthService = AuthService;

        LoginCommand = new DelegateCommand(
            () =>
            {
                _AuthService.Authentication(CurrentUser);
                
            });
        RegisrationCommand = new DelegateCommand(
            () =>
            {
                _navigationService.NavigateTo<RegistrationViewModel>();
            });
        ForgotPasswordCommand = new DelegateCommand(
            () =>
            {
                _navigationService.NavigateTo<RecoveryViewModel>();
            });
    }
}
