using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public interface IWeather
    {
        string Main { get; set; }

        string Describtion { get; set; }

        string Temperature { get; set; }

        string TemperatureFeels { get; set; }

        string Humidity { get; set; }
        
        string Pressure { get; set; }   

        string WindSpeed { get; set; }

    }
}
