using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public static class Helper
    {
        public static string ConvertToCelcjus(double value)
        {
            return Math.Round((value - 273), 2).ToString();
        }
    }
}
