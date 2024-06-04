using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class BackgroundImg
    {
        public ObservableCollection<Uri> PathList
        {
            get;
            private set;
        }

        private string cloudType { get; set; }
        public BackgroundImg(string cloudType)
        {
            this.cloudType = cloudType;

            this.PathList = new ObservableCollection<Uri>
            {

                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\brokenClouds.jpg", UriKind.Absolute),
                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\clearClouds.jpg", UriKind.Absolute),
                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\fewClouds.jpg", UriKind.Absolute),
                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\fogClouds.jpg", UriKind.Absolute),
                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\overcastClouds.jpg", UriKind.Absolute),
                new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\stormClouds.jpg", UriKind.Absolute)

            };
        }


        public Uri CloudType()
        {
            Uri path;

            switch (cloudType)
            {
                case "broken clouds":
                    path = PathList[0];
                    break;
                case "clear sky":
                    path = PathList[1];
                    break;
                case "few clouds":
                    path = PathList[2];
                    break;
                case "overcast clouds":
                    path = PathList[4];
                    break;
                default:
                    path = PathList[0];
                    break;

            }
            return path;
        }
    }
}
