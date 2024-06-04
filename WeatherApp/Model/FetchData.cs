using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class FetchData
    {
        public async Task<ICordinates> FetchCordinates(string url)
        {
            ICordinates cordinates = null;
            

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = await client.GetAsync(url);
                HttpContent content = message.Content;

                var cordData = await content.ReadAsStringAsync();
                if(cordData != null)
                {
                    var cordDataObj = JArray.Parse(cordData);
                    foreach (var item in cordDataObj)
                    {
                        cordinates = new Cordinates
                        {
                            Lat = Math.Round(item["lat"].Value<double>(), 2).ToString(),
                            Lon = Math.Round(item["lon"].Value<double>(), 2).ToString(),
                            City = item["name"].Value<string>()
                        };
                    }
                }

                client.Dispose();
                message.Dispose();
                content.Dispose();

                return cordinates ?? new Cordinates { Lat = "0", Lon = "0" };
            }
            catch (Exception)
            { 
                return cordinates ?? new Cordinates { Lat = "0", Lon = "0" };
            }


        }

        public async Task<IWeather> FetchWeather(string linkWeather)
        {
            IWeather weather = null;
            try
            {
                string main = string.Empty;
                string description = string.Empty;
                HttpClient client = new HttpClient();
                HttpResponseMessage message = await client.GetAsync(linkWeather);
                HttpContent content = message.Content;
                var data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    var dataObj = JsonConvert.DeserializeObject(data) as JObject;
                    var weatherinfo = dataObj["weather"].Children();
                    var tempInfo = dataObj["main"];
                    var windInfo = dataObj["wind"];


                    //Take info from Array
                    foreach (var item in weatherinfo)
                    {
                        main = item["main"].Value<string>();
                        description = item["description"].Value<string>();
                    }

                    //Implement info in interface
                    weather = new Weather
                    {
                        Describtion = description.ToUpper(),
                        Main = main.ToUpper(),
                        Temperature = Helper.ConvertToCelcjus(tempInfo.Value<double>("temp")),
                        TemperatureFeels = Helper.ConvertToCelcjus(tempInfo.Value<double>("feels_like")),
                        Pressure = tempInfo.Value<string>("pressure"),
                        Humidity = tempInfo.Value<string>("humidity"),
                        WindSpeed = windInfo.Value<string>("speed"),
                    };

                }

                client.Dispose();
                message.Dispose();
                content.Dispose();

                return weather ?? new Weather();
            }
            catch (Exception) { }
            {
                return new Weather();
            }
        }



        

    }
}
