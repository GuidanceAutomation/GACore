using System;
using System.Globalization;
using System.Windows.Data;

namespace GACore.Controls.Converters
{
    public class RadToDegStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double rad = (float)value;
            return rad.RadToDeg();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException("RadToDegStringConverter ConvertBack()");
    }
}