using System;
using System.Globalization;
using System.Windows.Data;

namespace GACore.Controls.Converters
{
    public class NullableBoolButtonStateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((bool?)value)
            {
                case true: return Properties.Resources.UI_ButtonStatus_Pressed;

                case false: return Properties.Resources.UI_ButtonStatus_Depressed;

                default:
                case null: return Properties.Resources.UI_ButtonStatus_Unknown;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}