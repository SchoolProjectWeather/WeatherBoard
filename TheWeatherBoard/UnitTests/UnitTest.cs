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
    /// <summary>
    /// Diese Klasse beinhaltet Unti Tests für in der Funktion benannte Funktionen des WeatherDispays
    /// </summary>
    public class UnitTest
    {

        /// <summary>
        /// Diese Funktion testet ob der currentWeatherService das Model beschreibt und nicht leer zurück gibt
        /// </summary>
        [Fact]
        public void GetCurrentWeatherTest()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "Stuttgart";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            currentWeatherModel = currentWeatherService.GetCurrentWeather(location);
            Assert.NotNull(currentWeatherModel);
            
        }

        /// <summary>
        /// Diese Funktion testet ob der currentWeatherService das Model beschreibt und nicht leer zurück gibt
        /// </summary>
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

        /// <summary>
        /// Diese Funktion testet ob eine Exception beim CurrentWeatherService geworfen wird, falls man eine Falsche Stadt eingibt
        /// </summary>
        [Fact]
        public void TestCityNotFoundException()
        {
            CurrentWeatherService currentWeatherService = new CurrentWeatherService();
            string location = "ojfwbwovbwqobi";
            CurrentWeatherModel currentWeatherModel = new CurrentWeatherModel();
            Assert.Throws<ArgumentException>(() => (currentWeatherService.GetCurrentWeather(location)));
        }

        /// <summary>
        /// Diese Funktion testet ob der ForecastService das Model beschreibt und nicht leer zurück gibt
        /// </summary>
        [Fact]
        public void GetForecastTest()
        {
            ForecastService forecastService = new ForecastService();
            string location = "Stuttgart";
            ForecastModel forecastModel = new ForecastModel();
            forecastModel = forecastService.GetForecast(location);
            Assert.NotNull(forecastModel);
        }

        /// <summary>
        /// Diese Funktion testet ob die Verschlüsselung eines String funktioniert
        /// </summary>
        [Fact]
        public void TestAESEncryption()
        {
            string encryptMe = "Christoph";
            string encrypted = AESEncryption.HashStringAes256(encryptMe);
            Assert.NotEqual(encrypted, encryptMe);
        }
    }
}
