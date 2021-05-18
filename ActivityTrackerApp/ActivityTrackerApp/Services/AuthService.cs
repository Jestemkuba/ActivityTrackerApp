using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityTrackerApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ActivityTrackerClient _client;

        public AuthService()
        {
            _client = new ActivityTrackerClient();
        }

        public User User { get; set; } =  new User();

        public async Task<RegisterResult> Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                var response = await _client.Register(registerRequestDto);
                User.Username = response.Username;
                User.Email = response.Email;
                return new RegisterResult
                {
                    IsSuccesful = true,
                };
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
                return new RegisterResult
                { 
                    Message = "Something went wrong",
                    IsSuccesful = false,
                };
            }
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
            catch (ApiException e)
            {
                return new LoginResult
                {
                    LoginSuccessful = false,
                };
            }
        }
    }
}
