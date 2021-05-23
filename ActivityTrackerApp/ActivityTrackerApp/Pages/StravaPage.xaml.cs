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
    public partial class StravaPage : ContentPage
    {
        private readonly StravaViewModel viewModel;
        public StravaPage()
        {
            InitializeComponent();

            BindingContext = App.Resolve<StravaViewModel>();
            viewModel = BindingContext as StravaViewModel;

            StravaWebView.Navigating += viewModel.OnWebViewNavigating;
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as StravaViewModel).Initialize();
            base.OnAppearing();
        }
    }
}