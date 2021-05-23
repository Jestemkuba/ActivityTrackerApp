using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models.DTOs;
using ActivityTrackerApp.Pages;
using ActivityTrackerApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{  
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly IActivityService _activityService;      
        private string _username;
        private string _password;
        private bool _validationMessageVisible;
        private bool _isLogging;
        private ICommand _loginCommand;
        private ICommand _goToRegisterCommand;

        public LoginViewModel(IAuthService authService, IActivityService activityService)
        {
            _authService = authService;
            _activityService = activityService;
        }
       
        public ICommand LoginCommand => _loginCommand ??= new Command(Login);

        public ICommand GoToRegisterCommand => _goToRegisterCommand ??= new Command(GoToRegister);
        public string Username 
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool ValidationMessageVisible 
        {
            get => _validationMessageVisible;
            set => SetProperty(ref _validationMessageVisible, value);
        }

        public bool IsLogging 
        {
            get => _isLogging;
            set => SetProperty(ref _isLogging, value);
        }

        private async void Login()
        {
            ValidationMessageVisible = false;
            IsLogging = true;
            var request = new LoginRequestDto
            {
                Username = Username,
                Password = Password,
            };

            var loginResponse = await _authService.Login(request);
            if (loginResponse.LoginSuccessful)
            {
                await Shell.Current.GoToAsync("///StartPage");
            }
            else
            {
                ValidationMessageVisible = true;
            }

            IsLogging = false;            
        }

        private async void GoToRegister()
        {
            var route = nameof(RegisterPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
