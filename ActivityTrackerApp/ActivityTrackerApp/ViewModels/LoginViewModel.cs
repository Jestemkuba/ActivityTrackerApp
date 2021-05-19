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
        private ICommand _loginCommand;
        private ICommand _goToRegisterCommand;
        private string _username;
        private string _password;

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

        private async void Login()
        {
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
               
        }

        private async void GoToRegister()
        {
            var route = nameof(RegisterPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
