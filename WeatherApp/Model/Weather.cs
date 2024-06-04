using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Weather : IWeather
    {
        public string Main { get; set; }
        public string Describtion { get; set; }
        public string Temperature { get; set; }
        public string TemperatureFeels { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
    }
}
