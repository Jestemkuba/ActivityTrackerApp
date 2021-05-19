using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.ViewModels
{
    public class ActivitiesViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private ObservableCollection<Activity> _activities;

        public ActivitiesViewModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

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
    }
}
