using ActivityTrackerApp.ViewModels;
using ActivityTrackerApp.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ActivityTrackerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ActivityDetailsPage), typeof(ActivityDetailsPage));
            Routing.RegisterRoute(nameof(AddActivityPage), typeof(AddActivityPage));

            //tab_bar.CurrentItem = activities;
        }

    }
}
