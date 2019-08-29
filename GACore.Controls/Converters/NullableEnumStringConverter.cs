using System;
using System.Globalization;
using System.Windows.Data;

namespace GACore.Controls.Converters
{
    public class NullableEnumStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? "null" : value.ToString();            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}