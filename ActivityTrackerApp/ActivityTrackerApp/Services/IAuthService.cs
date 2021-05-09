using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services
{
    interface IAuthService
    {
        public  Task<LoginResult> Login(LoginRequestDto loginRequestDto);
    }
}
