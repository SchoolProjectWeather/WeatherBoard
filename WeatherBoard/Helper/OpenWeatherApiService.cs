using OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBoard.Helper
{
   public class OpenWeatherApiService
    {
        
        public OpenWeatherApiService()
        {
                
        }

        public async Task <CurrentWeatherResponse> currentWeatherService(string pCity)
        {
            var client = new OpenWeatherMapClient("df1b80f131e96328741e25b186b378ba");
            var currentWeather = await client.CurrentWeather.GetByName($@"{pCity}", MetricSystem.Metric);
            var temperature= currentWeather.Temperature.Value;
            return currentWeather;
        }
    }
}
