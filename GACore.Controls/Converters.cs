using GACore.Architecture;
using GACore.Extensions;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GACore.Controls
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

	public class NullableBoolButtonStateStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((bool?)value)
			{
				case true: return "Status: Pressed";

				case false: return "Status: De-pressed";

				default:
				case null: return "Status: Unknown";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}

	public class NullableBoolStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((bool?)value)
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