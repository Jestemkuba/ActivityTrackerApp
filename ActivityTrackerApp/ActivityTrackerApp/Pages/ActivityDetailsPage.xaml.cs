using ActivityTrackerApp.Utilities;
using ActivityTrackerApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityDetailsPage : ContentPage
    {
        public ActivityDetailsPage()
        {
            BindingContext = App.Resolve<ActivityDetailsViewModel>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ActivityDetailsViewModel).Initialize().Await();
        }
    }
}