using ActivityTrackerApp.Models;
using ActivityTrackerApp.Popups;
using ActivityTrackerApp.Services;
using ActivityTrackerApp.Services.Contracts;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    class ActivityDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IActivityService _activityService;
        private readonly IPopupNavigation _popupNavigation;
        private Activity _activity;
        private int? _id;

        public ActivityDetailsViewModel(
            IActivityService activityService,
            IPopupNavigation popupNavigation)
        {
            _activityService = activityService;
            _popupNavigation = popupNavigation;
        }

        public Activity Activity
        {
            get => _activity;
            set => SetProperty(ref _activity, value);
        }

        public int? Id
        {
            get => _id;
            set => _id = value;
        }

        public override async Task Initialize()
        {
            if (Id is null)
                return;

            await _popupNavigation.PushAsync(new ProgressIndicatorPopupPage());
            Activity = (await _activityService.GetActivities()).FirstOrDefault(a => a.Id == Id.Value);
            await _popupNavigation.PopAllAsync();
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            var id = HttpUtility.UrlDecode(query["id"]);
            var idParsable = int.TryParse(id, out int result);

            Id = idParsable ? (int?)result : null;
        }
    }
}
