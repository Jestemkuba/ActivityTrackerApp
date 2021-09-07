using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Popups;
using ActivityTrackerApp.Services;
using ActivityTrackerApp.Services.Contracts;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private readonly IPopupNavigation _popupNavigation;
        private string _username;
        private Activity _lastActivity;
        private ICommand _goToAddActivityPageCommand;

        public StartViewModel(
            IActivityService activityService,
            IPopupNavigation popupNavigation)
        {
            _activityService = activityService;
            _popupNavigation = popupNavigation;
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public Activity LastActivity
        {
            get => _lastActivity;
            set => SetProperty(ref _lastActivity, value);
        }

        public ICommand GoToAddActivityPageCommand => _goToAddActivityPageCommand ??= new AsyncCommand(GoToAddActivityPage);

        public override async Task Initialize()
        {
            await _popupNavigation.PushAsync(new ProgressIndicatorPopupPage());
            await _activityService.GetActivities();
            var activities = await _activityService.GetActivities();
            LastActivity = (await _activityService.GetActivities()).FirstOrDefault();
            await _popupNavigation.PopAllAsync();
            await base.Initialize();
        }

        private async Task GoToAddActivityPage()
        {
            await Shell.Current.GoToAsync("AddActivityPage");
        }

    }
}
