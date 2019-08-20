using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System;

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
            FooKingpin kingpin = (FooKingpin)FindResource("fooKingpin");
            kingpin.Randomize();

            FooCallButton callButton = (FooCallButton)FindResource("fooCallButton");
            callButton.Randomize();
        }

        private void GoodButton_Click(object sender, RoutedEventArgs e)
        {
            FooKingpin kingpin = (FooKingpin)FindResource("fooKingpin");
            kingpin.SetGood();
        }
    }
}