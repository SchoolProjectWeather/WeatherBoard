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

                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\bewoelkt.png";
                    break;
                    
                case "02n":
                    iconSource = "C:\\Repos\\WEATHERBOARD\\WeatherBoard\\TheWeatherBoard\\Assets\\bewoelkt.png";
                    break;
                case "03d":
                    //source
                    break;
                case "04d":
                    //source
                    break;
                case "09d":
                    //source
                    break;
                case "10d":
                    //source
                    break;
                case "11d":
                    //source
                    break;
                case "13d":
                    //source
                    break;
                case "50d":
                    //source
                    break; ;
            }

            return iconSource;
        }
    }
}
