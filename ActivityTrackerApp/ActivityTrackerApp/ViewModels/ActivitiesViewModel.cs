using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Activity> _activities;

        public ActivitiesViewModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public ICommand NavigateToDetailsCommand => _navigateToDetailsCommand ??= new AsyncCommand<Activity>(NavigateToDetails);

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

        private async Task NavigateToDetails(Activity activity)
        {
            if (activity is null)
                return;

            await Shell.Current.GoToAsync($"ActivityDetailsPage?id={activity.Id}");
        }
    }
}
