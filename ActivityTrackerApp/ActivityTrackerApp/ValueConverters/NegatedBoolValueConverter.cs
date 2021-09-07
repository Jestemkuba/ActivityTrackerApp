using System;
using System.Globalization;
using Xamarin.Forms;

namespace ActivityTrackerApp.ValueConverters
{
    class NegatedBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
