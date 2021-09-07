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
    public partial class DefaultEntryView : StackLayout
    {

        public DefaultEntryView()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public string Input
        {
            get => (string)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(DefaultEntryView), null);

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(DefaultEntryView), null);

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create("IsPassword", typeof(bool), typeof(DefaultEntryView), null);

        public static readonly BindableProperty InputProperty =
            BindableProperty.Create("Input", typeof(string), typeof(DefaultEntryView), null, BindingMode.OneWayToSource);

    }
}