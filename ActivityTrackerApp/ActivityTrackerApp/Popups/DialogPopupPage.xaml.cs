using ActivityTrackerApp.Popups.ViewModels;
using Autofac;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DialogPopupPage : PopupPage
    {
        public DialogPopupPage(string content)
        {
            InitializeComponent();
            BindingContext = App.Resolve<DialogPopupViewModel>(new NamedParameter("content", content));
        }
    }
}