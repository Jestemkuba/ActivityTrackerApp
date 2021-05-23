using ActivityTrackerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitiesPage : ContentPage
    {
        public ActivitiesPage()
        {
            BindingContext = App.Resolve<ActivitiesViewModel>();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as ActivitiesViewModel).Initialize();
            base.OnAppearing();
        }
    }
}