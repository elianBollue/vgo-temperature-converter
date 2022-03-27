namespace Model
{
    public interface ITemperatureScale
    {
        string Name { get; }

        double ConvertToKelvin(double temperature);
        double ConvertFromKelvin(double temperature);
    }

    public class KelvingTemperatureScale : ITemperatureScale
    {
        public string Name => "Kelvin";

        public double ConvertFromKelvin(double kelvin)
        {
            return kelvin;
        }

        public double ConvertToKelvin(double kelvin)
        {
            return kelvin;
        }
    }

    public class CelsiusTemperatureScale : ITemperatureScale
    {
        public string Name => "Celsius";

        public double ConvertFromKelvin(double temperature)
        {
            return temperature - 273.15;
        }

        public double ConvertToKelvin(double temperature)
        {
            return temperature + 273.15;
        }
    }

    public class FahrenheitTemperatureScale : ITemperatureScale
    {
        public string Name => "Fahrenheit";

        public double ConvertFromKelvin(double temperature)
        {
            return temperature * 1.8 - 459.67;
        }

        public double ConvertToKelvin(double temperature)
        {
            return (temperature + 459.67) / 1.8;
        }
    }
}
