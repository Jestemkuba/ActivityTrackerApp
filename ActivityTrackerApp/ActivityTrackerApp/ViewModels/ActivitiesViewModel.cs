using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class ActivitiesViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private Command _navigateToDetailsCommand;
        private ObservableCollection<Activity> _activities;

        public ActivitiesViewModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public Command NavigateToDetailsCommand => _navigateToDetailsCommand ??= new Command<Activity>(NavigateToDetails);

        public ObservableCollection<Activity> Activities 
        {
            get => _activities;
            set => SetProperty(ref _activities, value);
        }

        public override Task Initialize()
        {
            Activities = _activityService.Activities;
            return base.Initialize();
        }

        private async void NavigateToDetails(Activity activity)
        {
            if (activity is null)
                return;

            await Shell.Current.GoToAsync($"ActivityDetailsPage?id={activity.Id}");
        }
    }
}
