using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Desktop.ViewModels;

class RegistrationViewModel : ViewModelBase
{
    private readonly INavigationServices _navigationService;
    private readonly IRegistrationService _registrationService;
    public User CurrentUser { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public DelegateCommand BackCommand { get; set; }
    public DelegateCommand RegistrationCommand { get; set; }

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
                    _registrationService.Registration(CurrentUser);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                MessageBox.Show("Registration completed successfully.");
                _navigationService.NavigateTo<AuthViewModel>();            

            });

    }
}
