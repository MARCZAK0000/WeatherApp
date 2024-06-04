using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.View;
namespace WeatherApp
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var WeatherApp = new WeathePage();
            WeatherApp.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}
