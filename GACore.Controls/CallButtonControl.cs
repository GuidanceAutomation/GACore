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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GACore.Controls
{
    public class CallButtonControl : Control
    {
        public static readonly DependencyProperty LightStateProperty =
            DependencyProperty.Register("LightState", typeof(LightState?),
            typeof(CallButtonControl), new PropertyMetadata(null));


        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.Register("IsPressed", typeof(bool?),
            typeof(CallButtonControl), new PropertyMetadata(null));

        public LightState? LightState
        {
            get { return (LightState?)GetValue(LightStateProperty); }
            set { SetValue(LightStateProperty, value); }
        }

        public bool? IsPressed
        {
            get { return (bool?)GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }

        static CallButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CallButtonControl), new FrameworkPropertyMetadata(typeof(CallButtonControl)));
        }
    }
}
