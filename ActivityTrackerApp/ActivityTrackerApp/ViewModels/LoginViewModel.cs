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

        public LoginViewModel()
        {
            _authService = new AuthService();
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand => _loginCommand ??= new Command(Login);

        private async void Login()
        {
            var request = new LoginRequestDto
            {
                Username = "azure",
                Password = "testtest96"
            };

            var loginResponse = await _authService.Login(request);
            if (loginResponse.LoginSuccessful)
                Console.WriteLine("LOGGED");

        }
    }
}
