using ActivityTrackerApp.Commands;
using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
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
        private string _name;
        private double _distance;
        private double _movingTime;
        private double _elapsedTime;
        private string _type;
        private double _averageSpeed;
        private double _maxSpeed;
        private ICommand _addActivityCommand;

        public AddActivityViewModel(IActivityService activityService)
        {
            _activityService = activityService;
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
        public double AverageSpeed 
        {
            get => _averageSpeed;
            set => SetProperty(ref _averageSpeed, value);
        }
        public double MaxSpeed 
        {
            get => _maxSpeed;
            set => SetProperty(ref _maxSpeed, value);
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
                AverageSpeed = AverageSpeed,
                MaxSpeed = MaxSpeed,
            };

            var result = await _activityService.AddActivity(activity);

            if (result != null)
                await Shell.Current.GoToAsync("//StartPage");
        }   
    }
}
