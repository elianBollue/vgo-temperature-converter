﻿using System;
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

        private void ConvertToCelsius(object sender, RoutedEventArgs e)
        {
            try
            {
                var fahrenheit = double.Parse(textBox.Text);
                var celsius = (fahrenheit - 32) / 1.8;
                celsiusBox.Text = celsius.ToString();
            }
            catch
            {
                celsiusBox.Text = "no strings allowed";
            }
        }

        private void ConvertToFahrenheit(object sender, RoutedEventArgs e)
        {
            try
            {
                var celsius = double.Parse(celsiusBox.Text);
                var fahrenheit = (celsius * 1.8) + 32;
                textBox.Text = fahrenheit.ToString();
            }
            catch
            {
                textBox.Text = "no strings allowed";
            }
        }

        private void ConvertKelvin(object sender, RoutedEventArgs e)
        {

        }
    }
}
