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

namespace View
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

        private void ConvertCelsius(object sender, RoutedEventArgs e)
        {
            try
            {
                var celsius = double.Parse(celsiusBox.Text);
                var fahrenheit = (celsius * 1.8) + 32;
                var kelvin = celsius + 273.15;
                FahrenBox.Text = fahrenheit.ToString();
                kelvinBox.Text = kelvin.ToString();
            }
            catch
            {
                celsiusBox.Text = "no strings allowed";
            }
        }

        private void ConvertFahrenheit(object sender, RoutedEventArgs e)
        {
            try
            {
                var fahrenheit = double.Parse(FahrenBox.Text);
                var celsius = (fahrenheit - 32) / 1.8;
                var kelvin = celsius + 273.15;
                celsiusBox.Text = celsius.ToString();
                kelvinBox.Text = kelvin.ToString();
            }
            catch
            {
                FahrenBox.Text = "no strings allowed";
            }
        }

        private void ConvertKelvin(object sender, RoutedEventArgs e)
        {
            try
            {
                var kelvin = double.Parse(kelvinBox.Text);
                var celsius = kelvin - 273.15;
                var fahrenheit = (celsius * 1.8) + 32;
                celsiusBox.Text = celsius.ToString();
                FahrenBox.Text = fahrenheit.ToString();
            }
            catch
            {
                kelvinBox.Text = "no strings allowed";
            }
        }
    }
}
