using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services
{
    public interface IAuthService
    {
        public Task<RegisterResult> Register(RegisterRequestDto registerRequestDto);
        public  Task<LoginResult> Login(LoginRequestDto loginRequestDto);
    }
}
