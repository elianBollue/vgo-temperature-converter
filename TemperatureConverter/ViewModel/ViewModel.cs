using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;
using Model;

namespace ViewModel
{
    public class ConvertViewModel
    {
        public ConvertViewModel()
        {
            this.TemperatureInKelvin = new Cell<double>();

            this.Kelvin = new TemperatureScaleViewModel(this, new KelvingTemperatureScale());
            this.Celsius = new TemperatureScaleViewModel(this, new CelsiusTemperatureScale());
            this.Fahrenheit = new TemperatureScaleViewModel(this, new FahrenheitTemperatureScale());
        }

        public Cell<double> TemperatureInKelvin { get; }

        public TemperatureScaleViewModel Kelvin { get; }

        public TemperatureScaleViewModel Celsius { get; }

        public TemperatureScaleViewModel Fahrenheit { get; }

        public IEnumerable<TemperatureScaleViewModel> Scales
        {
            get
            {
                yield return Celsius;
                yield return Fahrenheit;
                yield return Kelvin;
            }
        }
    }

    public class TemperatureScaleViewModel
    {
        private readonly ConvertViewModel parent;

        private readonly ITemperatureScale temperatureScale;

        public TemperatureScaleViewModel(ConvertViewModel parent, ITemperatureScale temperatureScale)
        {
            this.parent = parent;
            this.temperatureScale = temperatureScale;
            this.Temperature = this.parent.TemperatureInKelvin.Derive(kelvin => temperatureScale.ConvertFromKelvin(kelvin), t => temperatureScale.ConvertToKelvin(t));
            this.Increment = new AddCommand(this.Temperature, 1);
            this.Decrement = new AddCommand(this.Temperature, -1);
        }

        public ICommand Increment { get; }
        public ICommand Decrement { get; }
        public string Name => temperatureScale.Name;

        public Cell<double> Temperature { get; }
    }

    public class AddCommand : ICommand
    {
        private readonly Cell<double> cell;
        private readonly int delta;
        private readonly double minimum;
        private readonly double maximum;
        public AddCommand(Cell<double> cell, int delta)
        {
            this.cell = cell;
            this.delta = delta;
            this.minimum = 0;
            this.maximum = 1000;

            this.cell.PropertyChanged += (sender, args) => CanExecuteChanged(this, new EventArgs());
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            var nextValue = this.cell.Value + this.delta;
            return nextValue >= minimum && nextValue <= maximum;
        }
        public void Execute(object parameter)
        {
            cell.Value = Math.Round(cell.Value + delta);
        }
    }
}