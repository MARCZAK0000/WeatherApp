using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public interface ICordinates
    {
        string Lat { get; set; }

        string Lon { get; set; }

        string City { get; set; }
    }
}
