using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            ColorAnimation colorChangeAnimation = new ColorAnimation();
            colorChangeAnimation.From = Colors.White;
            colorChangeAnimation.To = lightStateControl.LightState.ToColor();
            colorChangeAnimation.Duration = TimeSpan.FromSeconds(2);
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
