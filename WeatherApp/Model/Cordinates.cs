using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Cordinates : ICordinates
    {
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string City { get; set; }
    }
}
