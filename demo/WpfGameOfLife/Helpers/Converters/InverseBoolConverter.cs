using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfGameOfLife.Helpers.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool boolValue)
                return !boolValue;
            throw new ArgumentException("value has to be a bool");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
