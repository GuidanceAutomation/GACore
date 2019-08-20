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
            FooKingpinStateReporter reporter = (FooKingpinStateReporter)FindResource("fooKingpinStateReporter");
            reporter.Randomize();

            FooCallButton callButton = (FooCallButton)FindResource("fooCallButton");
            callButton.Randomize();
        }

        private void GoodButton_Click(object sender, RoutedEventArgs e)
        {
            FooKingpinStateReporter reporter = (FooKingpinStateReporter)FindResource("fooKingpinStateReporter");
            reporter.SetGood();
        }
    }
}