using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherPageViewModel : ViewModelBase
    {
        private Uri _backgroundImgPath = new Uri("C:\\Users\\jjmar\\Desktop\\Projects\\WeatherAppProject\\WeatherApp\\Assets\\brokenClouds.jpg", UriKind.Absolute);

        public Uri BackgroundImgPath
        {
            get { return _backgroundImgPath; }
            set { _backgroundImgPath = value; OnPropetyChanged(nameof(BackgroundImgPath)); }
        }

        private FetchData _fetchdata;

        public FetchData FetchData
        {
            get { return _fetchdata; }
            set { _fetchdata = value; }
        }


        private BackgroundImg _backgroundImg;

        public BackgroundImg BackgroundImg
        {
            get { return _backgroundImg; }
            set { _backgroundImg = value; OnPropetyChanged(nameof(BackgroundImg)); }
        }


        private IWeather _weather;

        public IWeather Weather
        {
            get { return _weather; }
            set { _weather = value; OnPropetyChanged(nameof(Weather)); }
        }

        private ICordinates _cordinates;

        public ICordinates Cordinates
        {
            get { return _cordinates; }
            set { _cordinates = value; OnPropetyChanged(nameof(Cordinates)); }
        }

        private string _cityName = "Warsaw";

        public string CityName
        {
            get { return _cityName; }
            set 
            { 
                _cityName = value;
                OnPropetyChanged(nameof(CityName));
            }
        }



        public ICommand RefreshSearchCity { get; }
        public ICommand SearchCity { get; }
        public ICommand OpenGithub { get; }
        public ICommand OpenTwitter { get; }
        public ICommand OpenFacebook { get; }
        public WeatherPageViewModel()
        {
            SearchCityWeather(null);
            RefreshSearchCity = new ViewModelCommand(RefreshCity, CanRefreshCity);
            SearchCity = new ViewModelCommand(SearchCityWeather, CanSearchCityWeather);
            OpenGithub = new ViewModelCommand(OpenGitHubFunction, CanOpenTrue);
            OpenTwitter = new ViewModelCommand(OpenTwitterFunction, CanOpenTrue);
            OpenFacebook = new ViewModelCommand(OpenFacebookFunction, CanOpenTrue);
        }

        private void OpenFacebookFunction(object obj)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("https://facebook.com")
            {
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        private void OpenTwitterFunction(object obj)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("https://twitter.com")
            {
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        
        private void OpenGitHubFunction(object obj)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("https://github.com")
            {
                UseShellExecute = true
            };
            Process.Start(processStartInfo);
        }

        private bool CanOpenTrue(object obj)
        {
            return true;
        }


        private async void SearchCityWeather(object obj)
        {
            string cityCordUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={CityName}&appid=4013666679d9e61d19e62e90cac58e2f";
            FetchData = new FetchData();
            Cordinates = await FetchData.FetchCordinates(cityCordUrl);
            string weatherCity = $"https://api.openweathermap.org/data/2.5/weather?lat={Cordinates.Lat}&lon={Cordinates.Lon}&appid=4013666679d9e61d19e62e90cac58e2f";
            Weather = await FetchData.FetchWeather(weatherCity);
            BackgroundImg = new BackgroundImg(Weather.Describtion.ToLower());
            BackgroundImgPath = BackgroundImg.CloudType();
    
        }

        private bool CanSearchCityWeather(object obj)
        {
            if (string.IsNullOrEmpty(CityName))
            {
                return false;
            }
            return true;
        }

        private bool CanRefreshCity(object obj)
        {
            return true;
        }

        private void RefreshCity(object obj)
        {
            CityName = "City";
        }



    }
}
