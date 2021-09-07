using System;
using System.Globalization;
using Xamarin.Forms;

namespace ActivityTrackerApp.ValueConverters.UnitsOfMeasure
{
    class SecondsToStringRepresentationValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var seconds = (double)value;
            var time = TimeSpan.FromSeconds(seconds);

            var timeAsString = time.ToString(@"hh\:mm\:ss");
            return timeAsString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
