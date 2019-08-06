using System.Windows;

namespace GACore.DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomizeButton_Click(object sender, RoutedEventArgs e)
        {
            FooKingpinStatusReporter reporter = (FooKingpinStatusReporter)FindResource("fooKingpinStatusReporter");
            reporter.Randomize();
        }
    }
}