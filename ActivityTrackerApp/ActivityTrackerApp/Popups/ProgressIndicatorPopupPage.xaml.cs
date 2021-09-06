using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressIndicatorPopupPage : PopupPage
    {
        public ProgressIndicatorPopupPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}