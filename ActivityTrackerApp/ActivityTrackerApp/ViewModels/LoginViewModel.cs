using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models.DTOs;
using ActivityTrackerApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{  
    class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private ICommand _loginCommand;
        private string _username;
        private string _password;

        public LoginViewModel()
        {
            _authService = new AuthService();
        }

       
        public ICommand LoginCommand => _loginCommand ??= new Command(Login);
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
                Console.WriteLine("LOGGED");

        }
    }
}
