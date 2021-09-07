using ActivityTrackerApp.Client;
using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Models.DTOs;
using ActivityTrackerApp.Pages;
using ActivityTrackerApp.Popups;
using ActivityTrackerApp.Services;
using Refit;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly IPopupNavigation _popupNavigation;
        private string _username;
        private string _password;
        private bool _validationMessageVisible;
        private bool _isLogging;
        private ICommand _loginCommand;
        private ICommand _goToRegisterCommand;

        public LoginViewModel(
            IAuthService authService,
            IPopupNavigation popupNavigation)
        {
            _authService = authService;
            _popupNavigation = popupNavigation;
        }

        public ICommand LoginCommand => _loginCommand ??= new AsyncCommand(Login);

        public ICommand GoToRegisterCommand => _goToRegisterCommand ??= new AsyncCommand(GoToRegister);

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

        private async Task Login()
        {
            ValidationMessageVisible = false;
            IsLogging = true;

            var request = new LoginRequestDto
            {
                Username = Username,
                Password = Password,
            };

            try
            {
                var token = await _authService.Login(request);
                await SecureStorage.SetAsync("activity_tracker_api_token", token);
                await Shell.Current.GoToAsync("///StartPage");
            }
            catch (LoggingFailedException)
            {
                ValidationMessageVisible = true;
            }
            finally
            {
                IsLogging = false;
            }
        }

        private async Task GoToRegister()
        {
            var route = nameof(RegisterPage);
            await Shell.Current.GoToAsync(route);
        }
    }
}
