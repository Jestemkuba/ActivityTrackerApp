using ActivityTrackerApp.ViewModels;

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

            //StravaWebView.Navigating += viewModel.OnWebViewNavigating;
        }

        protected override async void OnAppearing()
        {
            await (BindingContext as StravaViewModel).Initialize();
            base.OnAppearing();
        }
    }
}