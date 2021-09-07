using System;
using System.Globalization;
using Xamarin.Forms;

namespace ActivityTrackerApp.ValueConverters.UnitsOfMeasure
{
    class MetersToKilometersValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var meters = (double)value;
            return meters / 1000;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
