using Desktop.Models;
using Desktop.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop.ViewModels;

class RegistrationViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IRegistrationService _registrationService;
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
    public string ConfirmPassword { get; set; }
    public DelegateCommand BackCommand { get; set; }
    public DelegateCommand RegistrationCommand { get; set; }

    public RegistrationViewModel(INavigationService navigationService, IRegistrationService registrationService)
    {
        _navigationService = navigationService;
        _registrationService = registrationService;

        BackCommand = new DelegateCommand(
    () =>
    {

    });

        RegistrationCommand = new DelegateCommand(
    () =>
    {


    });

    }
}
