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
            TemperatureOutput = model.main.temp + " C°";
            Description = model.weather[0].description;

        }

        private string _temperatureOutput;
        public string TemperatureOutput
        {
            get { return _temperatureOutput; }
            set
            {
                _temperatureOutput = value;
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
    }
}
