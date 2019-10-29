using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GACore.Controls.View
{
	public class DynamicLimiterStatusToOverlayTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			DynamicLimiterStatus status = (DynamicLimiterStatus)value;
			BrushCollection brushCollection = BrushDictionaries.DynamicLimiterStatusBrushCollectionDictionary.GetBrushCollection(status);

			BrushCollectionProperty property = (BrushCollectionProperty)parameter;
			return brushCollection.GetProperty(property);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}

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

	public class PositionControlStatusToOverlayTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			PositionControlStatus status = (PositionControlStatus)value;
			BrushCollection brushCollection = BrushDictionaries.PositionControlStatusBackgroundBrushCollectionDictionary.GetBrushCollection(status);

			BrushCollectionProperty property = (BrushCollectionProperty)parameter;
			return brushCollection.GetProperty(property);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}
