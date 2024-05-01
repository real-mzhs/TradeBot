using Desktop.Models;
using Desktop.Services.Classes;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Windows;

namespace Desktop.ViewModels.BigViewModels;

public class RegistrationViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationService;
    private readonly IRegistrationService _registrationService;
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
    public string ConfirmPassword { get; set; }
    public DelegateCommand BackCommand { get; set; }
    public DelegateCommand RegistrationCommand { get; set; }

    public DelegateCommand AuthCommand { get; set; }


    public RegistrationViewModel(INavigationServices navigationService, IRegistrationService registrationService)
    {
        _navigationService = navigationService;
        _registrationService = registrationService;

        BackCommand = new DelegateCommand(
            () =>
            {
                _navigationService.NavigateTo<AuthViewModel>();
            });

        RegistrationCommand = new DelegateCommand(
            () =>
            {
                try
                {
                    CheckDataService.CheckUserData(CurrentUser.Email, CurrentUser.Password, ConfirmPassword);
                    var response = _registrationService.RegistrationAsync(CurrentUser);
                    _navigationService.NavigateTo<AuthViewModel>();
                    MessageBox.Show("Registration completed successfully.");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });

        AuthCommand = new DelegateCommand(
          () =>
          {
              _navigationService.NavigateTo<AuthViewModel>();

          });



    }
}
