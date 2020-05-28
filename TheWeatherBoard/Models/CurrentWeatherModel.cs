using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Models
{
   public class CurrentWeatherModel
    {
        public string name { get; set; }
        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }
        }
        public Weather[] weather { get; set; }

        public CurrentWeatherModel()
        {
            this.weather = new Weather[1];
        }

        public class Main
        {
            public string temp { get; set; }

            public string feels_like { get; set; }
            public string temp_min { get; set; }
            public string temp_max { get; set; }
        }

        public Main main { get; set; }

        public class Wind
        {
            public double speed { get; set; }
        }
        public Wind wind { get; set; }
        public class Clouds
        {
            public int all { get; set; }
        }
        public Clouds clouds { get; set; }

        public class Sys
        {
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
        public Sys sys { get; set; }

    }
}
