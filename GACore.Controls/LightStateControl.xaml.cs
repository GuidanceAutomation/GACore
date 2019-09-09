using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GACore.Controls
{
	/// <summary>
	/// Interaction logic for LightStateControl.xaml
	/// </summary>
	public partial class LightStateControl : UserControl
	{
		public static readonly DependencyProperty LightStateProperty =
		   DependencyProperty.Register("LightState", typeof(LightState?),
		   typeof(LightStateControl),
		   new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnLightStateChanged)));

		public LightState? LightState
		{
			get { return (LightState?)GetValue(LightStateProperty); }
			set { SetValue(LightStateProperty, value); }
		}

		private static void OnLightStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			LightStateControl lightStateControl = (LightStateControl)d;

			Color target = lightStateControl.LightState.ToColor();

			ColorAnimation colorChangeAnimation = new ColorAnimation();
			colorChangeAnimation.From = Colors.White;
			colorChangeAnimation.To = target;
			colorChangeAnimation.Duration = TimeSpan.FromSeconds(1);
			colorChangeAnimation.AutoReverse = true;
			colorChangeAnimation.RepeatBehavior = RepeatBehavior.Forever;

			PropertyPath colorTargetPath = new PropertyPath("(Panel.Background).(SolidColorBrush.Color)");
			Storyboard CellBackgroundChangeStory = new Storyboard();
			Storyboard.SetTarget(colorChangeAnimation, lightStateControl.canvas);
			Storyboard.SetTargetProperty(colorChangeAnimation, colorTargetPath);
			CellBackgroundChangeStory.Children.Add(colorChangeAnimation);
			CellBackgroundChangeStory.Begin();
		}

		public LightStateControl()
		{
			InitializeComponent();
		}
	}
}