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
                    iconSource = "\\Assets\\01d.png";
                    break;
                case "02d":
                    iconSource = "\\Assets\\02d.png";
                    break;
                case "03d":
                    iconSource = "\\Assets\\03d.png";
                    break;
                case "04d":
                    iconSource = "\\Assets\\04d.png";
                    break;
                case "09d":
                    iconSource = "\\Assets\\09d.png";
                    break;
                case "10d":
                    iconSource = "\\Assets\\10d.png";
                    break;
                case "11d":
                    iconSource = "\\Assets\\11d.png";
                    break;
                case "13d":
                    iconSource = "\\Assets\\13d.png";
                    break;
                case "50d":
                    iconSource = "\\Assets\\50d.png";
                    break;

                case "01n":
                    iconSource = "\\Assets\\01d.png";
                    break;
                case "02n":
                    iconSource = "\\Assets\\02d.png";
                    break;
                case "03n":
                    iconSource = "\\Assets\\03d.png";
                    break;
                case "04n":
                    iconSource = "\\Assets\\04d.png";
                    break;
                case "09n":
                    iconSource = "\\Assets\\09d.png";
                    break;
                case "10n":
                    iconSource = "\\Assets\\10d.png";
                    break;
                case "11n":
                    iconSource = "\\Assets\\11d.png";
                    break;
                case "13n":
                    iconSource = "\\Assets\\13d.png";
                    break;
                case "50n":
                    iconSource = "\\Assets\\50d.png";
                    break;;
            }
            return iconSource;
        }
    }
}
