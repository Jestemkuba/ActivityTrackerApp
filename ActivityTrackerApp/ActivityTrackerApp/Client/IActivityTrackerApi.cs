using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Client
{
    interface IActivityTrackerApi
    {
        [Post("/auth/login")]
        Task<string> Login([Body]LoginRequestDto loginRequestDto);
    }
}
