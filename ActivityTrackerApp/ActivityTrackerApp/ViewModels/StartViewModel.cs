using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityTrackerApp.ViewModels
{
    class StartViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private string _username;

        public StartViewModel(IAuthService authService)
        {
            _authService = authService;
            Username = _authService.User.Username;
        }

        public string Username 
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

    }
}
