using ActivityTrackerApp.ViewModels;
using ActivityTrackerApp.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ActivityTrackerApp.Popups;

namespace ActivityTrackerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
        }

    }
}
