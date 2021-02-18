﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GACore.Controls
{
	internal class IsTrueColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool isTrue = (bool)value;

			return isTrue 
				? (SolidColorBrush)(new BrushConverter().ConvertFrom("#C4D92E"))
				: Brushes.Gray;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class NullableEnumStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == null 
				? "null" 
				: value.ToString();
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
}