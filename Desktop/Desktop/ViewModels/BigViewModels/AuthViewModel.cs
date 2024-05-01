using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Windows;
using Desktop.Services.Classes;
using Desktop.Models;

namespace Desktop.ViewModels.BigViewModels;

public class AuthViewModel : ViewModelBase
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
        get { return CurrentUser.Password; }
        set { CurrentUser.Password = value; }
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
                try
                {
                    CheckDataService.CheckUserData(CurrentUser.Email, CurrentUser.Password);
                    var response = _AuthService.AuthenticationAsync(CurrentUser).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                _navigationService.NavigateTo<BaseViewModel>();
            });
        RegisrationCommand = new DelegateCommand(
            () => { _navigationService.NavigateTo<RegistrationViewModel>(); });
        ForgotPasswordCommand = new DelegateCommand(
            () => { _navigationService.NavigateTo<RecoveryViewModel>(); });
    }
}