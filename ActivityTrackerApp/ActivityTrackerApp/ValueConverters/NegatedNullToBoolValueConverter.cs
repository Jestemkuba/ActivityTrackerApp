﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace ActivityTrackerApp.ValueConverters
{
    class NegatedNullToBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
