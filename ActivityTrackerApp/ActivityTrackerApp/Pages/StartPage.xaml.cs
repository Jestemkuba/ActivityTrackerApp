using ActivityTrackerApp.Utilities;
using ActivityTrackerApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            BindingContext = App.Resolve<StartViewModel>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as StartViewModel).Initialize().Await();
        }
    }
}