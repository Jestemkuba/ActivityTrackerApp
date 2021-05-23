using ActivityTrackerApp.Models;
using ActivityTrackerApp.Models.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Client
{
    class ActivityTrackerClient
    {
        private readonly IActivityTrackerApi _activityTrackerApi;

        public ActivityTrackerClient()
        {
            var activityTrackerApi = RestService.For<IActivityTrackerApi>("https://activitytrackerappapi.azurewebsites.net/api");
            _activityTrackerApi = activityTrackerApi;
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto)
        {
            var result = await _activityTrackerApi.Register(registerRequestDto);
            return result;
        }

        public async Task<string> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _activityTrackerApi.Login(loginRequestDto);
            return result;
        }

        public async Task<List<Activity>> GetActivities(string token)
        {
            try
            {
                var result = await _activityTrackerApi.GetActivities(token);
                return result;
            }
            catch (Exception ex)
            {
                var e = ex;
                throw;
            }
        }

        public async Task<string> SyncStravaAcitivites(string token, string stravaToken)
        {
            var result = await _activityTrackerApi.SyncStravaActivities(token, stravaToken);
            return result;
        }

        public async Task<Activity> AddActivity(string token, Activity activity)
        {
            var result = await _activityTrackerApi.AddActivity(token, activity);
            return result;
        }
    }
}
