using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Client.Contracts
{
    interface IActivityTrackerApi
    {
        [Post("/user")]
        Task<RegisterResponseDto> Register([Body] RegisterRequestDto registerRequestDto);

        [Post("/auth/login")]
        Task<string> Login([Body] LoginRequestDto loginRequestDto);

        [Get("/activities")]
        Task<IEnumerable<Activity>> GetActivities([Authorize("Bearer")] string token);

        [Post("/strava/syncstravaactivities")]
        Task<string> SyncStravaActivities([Authorize("Bearer")] string token, [Header("stravaauthtoken")] string stravaAuthToken);

        [Post("/activities")]
        Task<Activity> AddActivity([Authorize("Bearer")] string token, [Body] Activity activity);
    }
}
