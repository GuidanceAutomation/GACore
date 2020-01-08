using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GACore.Controls
{
	public class CheckboxButtonControl : Button
	{
		public static readonly DependencyProperty IsCheckedProperty =
			DependencyProperty.Register("IsChecked", typeof(bool),
			typeof(CheckboxButtonControl), new PropertyMetadata(false));

		public bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}

		static CheckboxButtonControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckboxButtonControl), new FrameworkPropertyMetadata(typeof(CheckboxButtonControl)));
		}
	}
}
