using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TheWeatherBoard.Helper
{
   public class IconPick
    {

        public string pickIcon(string iconId)
        {
            string iconSource="";
           
           
            string caseSwtich = iconId;

            switch (caseSwtich)
            {
                case "01d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\01d.png";
                    break;
                case "02d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\02d.png";
                    break;
                case "03d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\03d.png";
                    break;
                case "04d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\04d.png";
                    break;
                case "09d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\09d.png";
                    break;
                case "10d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\10d.png";
                    break;
                case "11d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\11d.png";
                    break;
                case "13d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\13d.png";
                    break;
                case "50d":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\50d.png";
                    break;



                case "01n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\01d.png";
                    break;
                case "02n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\02d.png";
                    break;
                case "03n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\03d.png";
                    break;
                case "04n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\04d.png";
                    break;
                case "09n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\09d.png";
                    break;
                case "10n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\10d.png";
                    break;
                case "11n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\11d.png";
                    break;
                case "13n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\13d.png";
                    break;
                case "50n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\50d.png";
                    break;



                    ;
            }

            return iconSource;
        }
    }
}
