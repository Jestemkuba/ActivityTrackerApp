using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityTrackerApp.Services
{
    class AuthService : IAuthService
    {
        private readonly ActivityTrackerClient _client;
        public AuthService()
        {
            _client = new ActivityTrackerClient();
        }
        public async Task<LoginResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var response = await _client.Login(loginRequestDto);
                await SecureStorage.SetAsync("activity_tracker_api_token", response);
                return new LoginResult
                {
                    LoginSuccessful = true,
                };
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    LoginSuccessful = false,
                };
            }
        }
    }
}
