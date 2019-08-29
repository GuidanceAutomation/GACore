using System;
using System.Globalization;
using System.Windows.Data;
using GACore.Architecture;
using GACore.Controls.Extensions;

namespace GACore.Controls.Converters
{
    public sealed class NavigationStatusToOverlayTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NavigationStatus status = (NavigationStatus)value;
            BrushCollection brushCollection = BrushDictionaries.NavigationStatusBackgroundBrushCollectionDictionary.GetBrushCollection(status);

            BrushCollectionProperty property = (BrushCollectionProperty)parameter;
            return brushCollection.GetProperty(property);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}