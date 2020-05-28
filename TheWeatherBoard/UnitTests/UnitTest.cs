using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeatherBoard.Models;
using TheWeatherBoard.Services;
using Xunit;
namespace TheWeatherBoard.UnitTests
{
   public class UnitTest
    {
        

        [Fact]
        public void getCurrentWeatherTest()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "Stuttgart";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            currentWeatherModel= currentWeatherService.GetCurrentWeather(location);
            Assert.NotNull(currentWeatherModel);
        }

        [Fact]
        public void getForecastTest()
        {
            ForecastService forecastService = new ForecastService();
            string location = "Stuttgart";
            ForecastModel forecastModel = new ForecastModel();
            forecastModel = forecastService.GetForecast(location);
            Assert.NotNull(forecastModel);
        }
    }
}
