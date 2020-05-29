using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Bases
{
   public class CalcuteConverter
    {
        
        /*Diese Methode ändert den als Unit Time Stamp geliertes sunset und sunrise um in ein DateTime Format, zudem wird der String
         * noch angepasst, sodass nur die Uhrzeit des sunsets und sunrise angezeigt wird
         */

        public string UnixTimeStampConverter(double timestamp)
        { 
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp);
            var time = Convert.ToString(dateTime);
            var convertedTime = time.Split(' ');
            return convertedTime[1];

        }      
    }
}
