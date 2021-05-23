using ActivityTrackerApp.Client;
using ActivityTrackerApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ActivityTrackerApp.Services
{
    class ActivityService : IActivityService
    {
        private readonly ActivityTrackerClient _client;

        public ActivityService()
        {
            _client = new ActivityTrackerClient();
        }

        public ObservableCollection<Activity> Activities { get; set; }

        public async Task GetActivities()
        {
            try
            {
                var token = await SecureStorage.GetAsync("activity_tracker_api_token");
                var list = await _client.GetActivities(token);
                list.Reverse();
                Activities = new ObservableCollection<Activity>(list);
            }
            catch (ApiException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    await Shell.Current.GoToAsync("///LoginPage");
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
            catch (ApiException)
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
                await GetActivities();
                return response;
            }
            catch (ApiException)
            {
                return null;
            }
        }
    }
}
