using ActivityTrackerApp.Client;
using ActivityTrackerApp.Exceptions;
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

        public User User { get; set; } = new User();

        public async Task Register(RegisterRequestDto registerRequestDto)
        {
            try
            {
                var response = await _client.Register(registerRequestDto);
            }
            catch (ApiException)
            {
                throw new UserRegisterFailedException();
            }
        }

        public async Task<string> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var token = await _client.Login(loginRequestDto);

                return token;
            }
            catch (ApiException)
            {
                throw new LoggingFailedException();
            }
        }
    }
}
