using System;
using System.Globalization;
using System.Windows.Data;
using GACore.Architecture;

namespace GACore.Controls.Converters
{
    public class IsInFaultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IKingpinState kingpinState = value as IKingpinState;
            return kingpinState.IsInFault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}