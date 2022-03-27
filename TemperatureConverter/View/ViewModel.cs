using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ConvertViewModel : INotifyPropertyChanged
    {
        private double temperatureInKelvin;
        public event PropertyChangedEventHandler PropertyChanged;
        public TemperatureScaleViewModel Kelvin { get; }
        public TemperatureScaleViewModel Fahrenheit { get; }
        public TemperatureScaleViewModel Celsius { get; }

        public ConvertViewModel()
        {
            this.Kelvin = new TemperatureScaleViewModel(this, new KelvingTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
        }

        public double TemperatureInKelvin
        {
            get
            {
                return temperatureInKelvin;
            }
            set
            {
                temperatureInKelvin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
            }
        }
    }

    public class TemperatureScaleViewModel : INotifyPropertyChanged
    {
        private readonly ITemperatureScale temperatureScale;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ConvertViewModel parent;

        public TemperatureScaleViewModel(ConvertViewModel parent, ITemperatureScale temperatureScale)
        {
            this.parent = parent;
            this.temperatureScale = temperatureScale;

            this.parent.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
        }
        public String Name => temperatureScale.Name;
        public double Temperature
        {
            get
            {
                return temperatureScale.ConvertFromKelvin(parent.TemperatureInKelvin);
            }
            set
            {
                parent.TemperatureInKelvin = temperatureScale.ConvertToKelvin(value);
            }
        }
    }
}