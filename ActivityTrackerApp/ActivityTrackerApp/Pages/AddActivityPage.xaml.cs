using ActivityTrackerApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddActivityPage : ContentPage
    {
        public AddActivityPage()
        {
            BindingContext = App.Resolve<AddActivityViewModel>();
            InitializeComponent();
        }
    }
}