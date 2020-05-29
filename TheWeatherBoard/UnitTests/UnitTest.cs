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
        public void GetCurrentWeatherTest()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "Stuttgart";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            currentWeatherModel = currentWeatherService.GetCurrentWeather(location);
            Assert.NotNull(currentWeatherModel);
        }


        [Fact]
        public void GetCurrentWeatherDescriptionTest()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "Stuttgart";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            currentWeatherModel = currentWeatherService.GetCurrentWeather(location);
            string description= currentWeatherModel.weather[0].description;
            Assert.NotNull(currentWeatherModel);
        }

        [Fact]
        public void TestCityNotFoundException()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "ojfwbwovbwqobi";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            Assert.Throws<ArgumentException>(() => (currentWeatherService.GetCurrentWeather(location)));
        }

        [Fact]
        public void GetForecastTest()
        {
            ForecastService forecastService = new ForecastService();
            string location = "Stuttgart";
            ForecastModel forecastModel = new ForecastModel();
            forecastModel = forecastService.GetForecast(location);
            Assert.NotNull(forecastModel);
        }
        [Fact]
        public void TestAESEncryption()
        {
            string encryptMe = "Christoph";
            string encrypted = AESEncryption.HashStringAes256(encryptMe);
            Assert.NotEqual(encrypted, encryptMe);
        }
    }
}
