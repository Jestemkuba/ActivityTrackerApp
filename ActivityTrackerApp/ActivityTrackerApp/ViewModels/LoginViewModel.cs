using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models.DTOs;
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
        private readonly ActivityTrackerClient _client;

        public LoginViewModel()
        {
            _client = new ActivityTrackerClient();
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand => _loginCommand ??= new Command(Login);

        private async void Login()
        {
            var request = new LoginRequestDto
            {
                Username = "azure",
                Password = "testtest9"
            };

            try
            {
                var result = await _client.Login(request);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
