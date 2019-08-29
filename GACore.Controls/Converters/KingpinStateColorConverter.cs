using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using GACore.Architecture;

namespace GACore.Controls.Converters
{
    public class KingpinStateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IKingpinState kingpinState = value as IKingpinState;
            return kingpinState.IsVirtual ? Brushes.Cyan : Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException("KingpinStateColorConverter ConvertBack()");
    }
}