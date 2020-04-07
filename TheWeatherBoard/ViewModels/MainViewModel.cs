using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Models;
using TheWeatherBoard.Services;

namespace TheWeatherBoard.ViewModels
{
  public class MainViewModel: ViewModelBase
    {
        CurrentWeatherService currentWeatherService = new CurrentWeatherService();
        public ButtonCommandBase ShowWeatherCommand { get; private set; }
        public MainViewModel()
        {
            ShowWeatherCommand = new ButtonCommandBase(ShowWeather);
        }

        private void ShowWeather()
        {
            CurrentWeatherModel model = new CurrentWeatherModel();
            model= currentWeatherService.GetCurrentWeather(Location);

            Temperature = model.main.temp + " C°";
            Description = model.weather[0].description;
            TempFeelsLike = "Feels Like: " + model.main.feels_like + " C°";
            TempMin ="Min Temperature: "+ model.main.temp_min + " C°";
            TempMax = "Max Temperature: " + model.main.temp_max + " C°";
            WindSpeed = "Wind Speed: " + model.wind.speed + "m/s";
            City = "City: " + model.name;
            Sunset = Convert.ToString( model.sys.sunset);
            Sunrise = Convert.ToString( model.sys.sunrise);

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
