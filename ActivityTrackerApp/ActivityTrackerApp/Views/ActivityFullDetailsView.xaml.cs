using ActivityTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActivityTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityFullDetailsView : ContentView
    {
        public ActivityFullDetailsView()
        {
            InitializeComponent();
        }

        public Activity Activity 
        {
            get => (Activity)GetValue(ActivityProperty);
            set => SetValue(ActivityProperty, value);
        }

        public static readonly BindableProperty ActivityProperty =
            BindableProperty.Create("Activity", typeof(Activity), typeof(ActivityFullDetailsView), null);
    }
}