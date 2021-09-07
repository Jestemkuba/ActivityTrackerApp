using ActivityTrackerApp.Client;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityTrackerApp.Services
{
    class ActivityService : IActivityService
    {
        private readonly ActivityTrackerClient _client;

        public ActivityService()
        {
            _client = new ActivityTrackerClient();
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            try
            {
                var token = await SecureStorage.GetAsync("activity_tracker_api_token");
                var activities = await _client.GetActivities(token);

                return activities.Reverse();

            }
            catch (FetchingEntityFailedException)
            {
                throw;
            }
        }

        public async Task SyncStravaActivities(string stravaToken)
        {
            try
            {
                var token = await SecureStorage.GetAsync("activity_tracker_api_token");
                var response = await _client.SyncStravaAcitivites(token, stravaToken);
                await GetActivities();
            }
            catch (StravaSynchroniseFailedException)
            {
                throw;
            }
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            try
            {
                var token = await SecureStorage.GetAsync("activity_tracker_api_token");
                var response = await _client.AddActivity(token, activity);
                return response;
            }
            catch (AddingEntityFailedException)
            {
                throw;
            }
        }
    }
}
