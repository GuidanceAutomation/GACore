using System;
using System.Globalization;
using System.Windows.Data;

namespace GACore.Controls.Converters
{
    public class NullableBoolStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            switch((bool?)value)
            {
                case true: return "True";

                case false: return "False";

                default:
                case null: return "null";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}