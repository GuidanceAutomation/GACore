using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GACore.Controls;
using System.Windows.Media;

namespace GACore.Controls.View
{
	public class IsInFaultConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IKingpinState kingpinState = value as IKingpinState;
			if (kingpinState != null) return kingpinState.IsInFault();
			else return true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}

	public class KingpinStateColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			IKingpinState kingpinState = value as IKingpinState;
			if (kingpinState != null) return kingpinState.IsVirtual ? Brushes.Cyan : Brushes.Black;
			else return Brushes.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException("KingpinStateColorConverter ConvertBack()");
	}

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
