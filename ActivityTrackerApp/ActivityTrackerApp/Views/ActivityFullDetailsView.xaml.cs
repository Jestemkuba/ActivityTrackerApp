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

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public double Distance
        {
            get { return (double)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }

        public double MovingTime
        {
            get { return (double)GetValue(MovingTimeProperty); }
            set { SetValue(MovingTimeProperty, value); }
        }

        public double ElapsedTime
        {
            get { return (double)GetValue(ElapsedTimeProperty); }
            set { SetValue(ElapsedTimeProperty, value); }
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public double AverageSpeed
        {
            get { return (double)GetValue(AverageSpeedProperty); }
            set { SetValue(AverageSpeedProperty, value); }
        }

        public double MaxSpeed
        {
            get { return (double)GetValue(MaxSpeedProperty); }
            set { SetValue(MaxSpeedProperty, value); }
        }

        public static readonly BindableProperty NameProperty =
         BindableProperty.Create("Name", typeof(string), typeof(ActivityFullDetailsView), null);

        public static readonly BindableProperty DistanceProperty =
         BindableProperty.Create("Distance", typeof(double), typeof(ActivityFullDetailsView), default(double));

        public static readonly BindableProperty MovingTimeProperty =
         BindableProperty.Create("MovingTime", typeof(double), typeof(ActivityFullDetailsView), default(double));

        public static readonly BindableProperty ElapsedTimeProperty =
         BindableProperty.Create("ElapsedTime", typeof(double), typeof(ActivityFullDetailsView), default(double));

        public static readonly BindableProperty TypeProperty =
         BindableProperty.Create("Type", typeof(string), typeof(ActivityFullDetailsView),null);

        public static readonly BindableProperty AverageSpeedProperty =
         BindableProperty.Create("AverageSpeed", typeof(double), typeof(ActivityFullDetailsView), default(double));

        public static readonly BindableProperty MaxSpeedProperty =
         BindableProperty.Create("MaxSpeed", typeof(double), typeof(ActivityFullDetailsView), default(double));
    }
}