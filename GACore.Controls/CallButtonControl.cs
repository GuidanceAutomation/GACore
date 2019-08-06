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
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(string),
                typeof(CallButtonControl), new PropertyMetadata(false, IsCheckedChanged));
        public bool IsChecked { get; set; }

        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CallButtonControl)d).IsChecked = (bool)e.NewValue;
        }

        static CallButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CallButtonControl), new FrameworkPropertyMetadata(typeof(CallButtonControl)));
        }
    }
}
