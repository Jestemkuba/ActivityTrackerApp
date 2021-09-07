using ActivityTrackerApp.Utilities;
using ActivityTrackerApp.ViewModels;

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

        protected override void OnAppearing()
        {
            (BindingContext as ActivitiesViewModel).Initialize().Await();
            base.OnAppearing();
        }
    }
}