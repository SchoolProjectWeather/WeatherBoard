using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using Renci.SshNet.Messages;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Helper;
using TheWeatherBoard.Models;
using TheWeatherBoard.Services;

namespace TheWeatherBoard.ViewModels
{
  public class MainViewModel: ViewModelBase
    {

        public CalcuteConverter calcuteConverter;
        public CurrentWeatherService currentWeatherService;
        public ForecastService forecastService;

        public IconPick iconPick;
        public ButtonCommandBase ShowWeatherCommand { get; private set; }
        public ButtonCommandBase ForcastCommand { get; }

        public MainViewModel()
        {  
            iconPick = new IconPick();
            calcuteConverter = new CalcuteConverter();
            currentWeatherService = new CurrentWeatherService();
            ShowWeatherCommand = new ButtonCommandBase(ShowWeather);
            ForcastCommand = new ButtonCommandBase(ShowForecast);
            forecastService = new ForecastService();
        }

        private void ShowWeather()
        {
            CurrentWeatherModel model = new CurrentWeatherModel();
            model = currentWeatherService.GetCurrentWeather(Location);

            Temperature = model.main.temp + " C°";
            Description = model.weather[0].description;
            TempFeelsLike = "Feels Like: " + model.main.feels_like + " C°";
            TempMin = "Min Temperature: " + model.main.temp_min + " C°";
            TempMax = "Max Temperature: " + model.main.temp_max + " C°";
            WindSpeed = "Wind Speed: " + model.wind.speed + "m/s";
            City = model.name;
            Sunrise = calcuteConverter.UnixTimeStampConverter(model.sys.sunrise);
            Sunset = calcuteConverter.UnixTimeStampConverter(model.sys.sunset);
            WeatherIcon = iconPick.pickIcon(model.weather[0].icon);
        }

        private void ShowForecast()
        {
            ForecastModel model = new ForecastModel();
            model = forecastService.GetForecast(Location);

            string test;
            foreach (var x in model.list)
            {
               test = x.main.temp.ToString() + x.main.temp.ToString();
                MessageBox.Show(test);
            }


            // Use this to Debug Forecast Output
            JsonConvert.SerializeObject(model, Formatting.Indented);


        }


        private string _listTemp;
        public string ListTemp
        {
            get { return _listTemp; }
            set
            {
                _listTemp = value;
                OnPropertyChanged();
            }
        }

        private string _weatherIcon;
        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set
            {
                _weatherIcon = value;
                OnPropertyChanged();
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }


        private string _temperature;
        public string Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

    

        private string _descrition;
        public string Description
        {
            get { return _descrition; }
            set
            {
                _descrition = value;
                OnPropertyChanged();
            }
        }

        private string _tempFeelsLike;
        public string TempFeelsLike
        {
            get { return _tempFeelsLike; }
            set
            {
                _tempFeelsLike = value;
                OnPropertyChanged();
            }
        }

        private string _tempMax;
        public string TempMax
        {
            get { return _tempMax; }
            set
            {
                _tempMax = value;
                OnPropertyChanged();
            }
        }

        private string _tempMin;
        public string TempMin
        {
            get { return _tempMin; }
            set
            {
                _tempMin = value;
                OnPropertyChanged();
            }
        }

        private string _windSpeed;
        public string WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                _windSpeed = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        private string _sunset;
        public string Sunset
        {
            get { return _sunset; }
            set
            {
                _sunset = value;
                OnPropertyChanged();
            }
        }

        private string _sunrise;
        public string Sunrise
        {
            get { return _sunrise; }
            set
            {
                _sunrise = value;
                OnPropertyChanged();
            }
        }
    }
}
