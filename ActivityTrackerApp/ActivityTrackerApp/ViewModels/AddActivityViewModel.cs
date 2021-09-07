using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Exceptions;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Popups;
using ActivityTrackerApp.Services;
using ActivityTrackerApp.Services.Contracts;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    class AddActivityViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private readonly IPopupNavigation _popupNavigation;
        private string _name;
        private double _distance;
        private double _movingTime;
        private double _elapsedTime;
        private string _type;
        private ICommand _addActivityCommand;

        public AddActivityViewModel(
            IActivityService activityService,
            IPopupNavigation popupNavigation)
        {
            _activityService = activityService;
            _popupNavigation = popupNavigation;
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public double Distance
        {
            get => _distance;
            set => SetProperty(ref _distance, value);
        }

        public double MovingTime
        {
            get => _movingTime;
            set => SetProperty(ref _movingTime, value);
        }

        public double ElapsedTime
        {
            get => _elapsedTime;
            set => SetProperty(ref _elapsedTime, value);
        }

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public ICommand AddActivityCommand => _addActivityCommand ??= new AsyncCommand(AddActivity);

        private async Task AddActivity()
        {
            var activity = new Activity
            {
                Name = Name,
                Distance = Distance,
                MovingTime = MovingTime,
                Type = Type,
                ElapsedTime = ElapsedTime,
            };

            try
            {
                await _popupNavigation.PushAsync(new ProgressIndicatorPopupPage());
                var result = await _activityService.AddActivity(activity);
                await Shell.Current.GoToAsync("//StartPage");
            }
            catch (AddingEntityFailedException)
            {
            }
            finally
            {
                await _popupNavigation.PopAllAsync();
            }
        }
    }
}
