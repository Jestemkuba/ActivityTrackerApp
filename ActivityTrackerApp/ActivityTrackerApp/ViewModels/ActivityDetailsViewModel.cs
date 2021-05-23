using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    class ActivityDetailsViewModel : BaseViewModel,IQueryAttributable
    {
        private readonly IActivityService _activityService;
        private Activity _activity;

        public ActivityDetailsViewModel(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public Activity Activity 
        {
            get => _activity;
            set => SetProperty(ref _activity, value);
        }
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            var id = HttpUtility.UrlDecode(query["id"]);
            var activity = _activityService.Activities.FirstOrDefault(a => a.Id == Int32.Parse(id));
            Activity = activity;
        }
    }
}
