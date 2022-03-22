using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel;
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

            this.DataContext = new ConvertViewModel(); //werkt per control, nu datacontext voor hele window gezet, controls inheriten van parents
        }
    }
    public class TemperatureConverter : IValueConverter
    {
        public ITemperatureScale TemperatureScale { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double kelvin = (double)value;

            return TemperatureScale.ConvertFromKelvin(kelvin).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double temperature = double.Parse((string)value);

            return TemperatureScale.ConvertToKelvin(temperature);
        }
    }
}
