using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using ActivityTrackerApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class ActivitiesViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private ICommand _navigateToDetailsCommand;
        private IEnumerable<Activity> _activities;

        public ActivitiesViewModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public ICommand NavigateToDetailsCommand => _navigateToDetailsCommand ??= new AsyncCommand<Activity>(NavigateToDetails);

        public IEnumerable<Activity> Activities
        {
            get => _activities;
            set => SetProperty(ref _activities, value);
        }

        public override async Task Initialize()
        {
            var activities = await _activityService.GetActivities();

            if (!activities.Any())
                return;

            Activities = await _activityService.GetActivities();
        }

        private async Task NavigateToDetails(Activity activity)
        {
            if (activity is null)
                return;

            await Shell.Current.GoToAsync($"ActivityDetailsPage?id={activity.Id}");
        }
    }
}
