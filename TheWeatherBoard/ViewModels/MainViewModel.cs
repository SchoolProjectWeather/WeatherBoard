using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Helper;
using TheWeatherBoard.Models;
using TheWeatherBoard.Services;

namespace TheWeatherBoard.ViewModels
{
  public class MainViewModel: ViewModelBase
  {
        public static string city_name;
      
        public LoginServiceSQL loginservice;
        public CalcuteConverter calcuteConverter;
        public CurrentWeatherService currentWeatherService;
        public ForecastService forecastService;
        public IconPick iconPick;
        public ButtonCommandBase ShowWeatherCommand { get; private set; }
        public ButtonCommandBase SetFavoriteCityCommand { get; set; }
        public ObservableCollection<string> CityOutput { get; set; }
        

        public MainViewModel()
        {  
            loginservice = new LoginServiceSQL();
            iconPick = new IconPick();
            calcuteConverter = new CalcuteConverter();
            currentWeatherService = new CurrentWeatherService();
            ShowWeatherCommand = new ButtonCommandBase(ShowWeather);
            SetFavoriteCityCommand = new ButtonCommandBase(addFavoriteCity);
            forecastService = new ForecastService();
            CityOutput = new ObservableCollection<string>();
            
            ShowWeatherStartup();
        }

        private async void  ShowWeather()
        {
            //CurrentWeather
            CurrentWeatherModel model = new CurrentWeatherModel();
            model= await Task.Run(()=> currentWeatherService.GetCurrentWeather(Location));

            MainViewModel.city_name = model.name;
            
            Temperature = model.main.temp + " C°";
            Description = "Description: "+ model.weather[0].description;
            TempFeelsLike = "Feels Like: " + model.main.feels_like + "C°";
            TempMin ="Min Temperature: "+ model.main.temp_min + "C°";
            TempMax = "Max Temperature: " + model.main.temp_max +  "C°";
            WindSpeed = "Wind Speed: " + model.wind.speed + "m/s";
            City = model.name;
            Sunrise = "sunrise: "+ calcuteConverter.UnixTimeStampConverter(model.sys.sunrise);
            Sunset = "sunset: "+ calcuteConverter.UnixTimeStampConverter(model.sys.sunset);
            WeatherIcon= iconPick.pickIcon(model.weather[0].icon);

            //WeatherForecast
            ForecastModel modelForecast = new ForecastModel();
            modelForecast = await Task.Run(() => forecastService.GetForecast(Location));
            DateTime thisDay = DateTime.Now;
            string date = thisDay.GetDateTimeFormats('D')[0];
            Day1 ="Heute";
            Icon1 = iconPick.pickIcon(modelForecast.list[4].weather[0].icon);
            Description1 = modelForecast.list[4].weather[0].description;
            Degree1 = Convert.ToString(modelForecast.list[4].main.temp_min) + "C°";
            TempMax1 = Convert.ToString(modelForecast.list[4].main.temp_max) + "C°";

            string date2 = thisDay.AddDays(1).GetDateTimeFormats('D')[0];
            Day2 = date2.Split(',')[0];
            Icon2 = iconPick.pickIcon(modelForecast.list[12].weather[0].icon);
            Description2 = modelForecast.list[12].weather[0].description;
            Degree2 = Convert.ToString(modelForecast.list[12].main.temp_min) + "C°";
            TempMax2 = Convert.ToString(modelForecast.list[12].main.temp_max) + "C°";


            string date3 = thisDay.AddDays(2).GetDateTimeFormats('D')[0];
            Day3 = date3.Split(',')[0];
            Icon3 = iconPick.pickIcon(modelForecast.list[20].weather[0].icon);
            Description3 = modelForecast.list[20].weather[0].description;
            Degree3 = Convert.ToString(modelForecast.list[20].main.temp_min) + "C°";
            TempMax3 = Convert.ToString(modelForecast.list[20].main.temp_max) + "C°";


            string date4 = thisDay.AddDays(3).GetDateTimeFormats('D')[0];
            Day4 = date4.Split(',')[0];
            Icon4 = iconPick.pickIcon(modelForecast.list[28].weather[0].icon);
            Description4 = modelForecast.list[28].weather[0].description;
            Degree4 = Convert.ToString(modelForecast.list[28].main.temp_min) + "C°";
            TempMax4 = Convert.ToString(modelForecast.list[28].main.temp_max) + "C°";

            string date5 = thisDay.AddDays(4).GetDateTimeFormats('D')[0];
            Day5 = date5.Split(',')[0];
            Icon5 = iconPick.pickIcon(modelForecast.list[36].weather[0].icon);
            Description5 = modelForecast.list[36].weather[0].description;
            Degree5 = Convert.ToString(modelForecast.list[36].main.temp_min) + "C°";
            TempMax5 = Convert.ToString(modelForecast.list[36].main.temp_max) + "C°";


        }
        
        private async void  ShowWeatherStartup()
        {
            
            string favCity = currentWeatherService.readFavCity();

            //CurrentWeather
            CurrentWeatherModel model = new CurrentWeatherModel();
            model= await Task.Run(()=> currentWeatherService.GetCurrentWeather(favCity));

            MainViewModel.city_name = model.name;
            
            Temperature = model.main.temp + " C°";
            Description = "Description: "+ model.weather[0].description;
            TempFeelsLike = "Feels Like: " + model.main.feels_like + "C°";
            TempMin ="Min Temperature: "+ model.main.temp_min + "C°";
            TempMax = "Max Temperature: " + model.main.temp_max +  "C°";
            WindSpeed = "Wind Speed: " + model.wind.speed + "m/s";
            City = model.name;
            Sunrise = "sunrise: "+ calcuteConverter.UnixTimeStampConverter(model.sys.sunrise);
            Sunset = "sunset: "+ calcuteConverter.UnixTimeStampConverter(model.sys.sunset);
            WeatherIcon= iconPick.pickIcon(model.weather[0].icon);

            //WeatherForecast
            ForecastModel modelForecast = new ForecastModel();
            modelForecast = await Task.Run(() => forecastService.GetForecast(favCity));
            DateTime thisDay = DateTime.Now;
            string date = thisDay.GetDateTimeFormats('D')[0];
            Day1 ="Heute";
            Icon1 = iconPick.pickIcon(modelForecast.list[4].weather[0].icon);
            Description1 = modelForecast.list[4].weather[0].description;
            Degree1 = Convert.ToString(modelForecast.list[4].main.temp_min) + "C°";
            TempMax1 = Convert.ToString(modelForecast.list[4].main.temp_max) + "C°";

            string date2 = thisDay.AddDays(1).GetDateTimeFormats('D')[0];
            Day2 = date2.Split(',')[0];
            Icon2 = iconPick.pickIcon(modelForecast.list[12].weather[0].icon);
            Description2 = modelForecast.list[12].weather[0].description;
            Degree2 = Convert.ToString(modelForecast.list[12].main.temp_min) + "C°";
            TempMax2 = Convert.ToString(modelForecast.list[12].main.temp_max) + "C°";


            string date3 = thisDay.AddDays(2).GetDateTimeFormats('D')[0];
            Day3 = date3.Split(',')[0];
            Icon3 = iconPick.pickIcon(modelForecast.list[20].weather[0].icon);
            Description3 = modelForecast.list[20].weather[0].description;
            Degree3 = Convert.ToString(modelForecast.list[20].main.temp_min) + "C°";
            TempMax3 = Convert.ToString(modelForecast.list[20].main.temp_max) + "C°";


            string date4 = thisDay.AddDays(3).GetDateTimeFormats('D')[0];
            Day4 = date4.Split(',')[0];
            Icon4 = iconPick.pickIcon(modelForecast.list[28].weather[0].icon);
            Description4 = modelForecast.list[28].weather[0].description;
            Degree4 = Convert.ToString(modelForecast.list[28].main.temp_min) + "C°";
            TempMax4 = Convert.ToString(modelForecast.list[28].main.temp_max) + "C°";

            string date5 = thisDay.AddDays(4).GetDateTimeFormats('D')[0];
            Day5 = date5.Split(',')[0];
            Icon5 = iconPick.pickIcon(modelForecast.list[36].weather[0].icon);
            Description5 = modelForecast.list[36].weather[0].description;
            Degree5 = Convert.ToString(modelForecast.list[36].main.temp_min) + "C°";
            TempMax5 = Convert.ToString(modelForecast.list[36].main.temp_max) + "C°";


        }

        private void addFavoriteCity()
        {
            try
            {
                currentWeatherService.updateFavCity(MainViewModel.city_name, LoginServiceSQL.userid);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
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

        LocationSql myVerbindung = new LocationSql();
        private string _location;
        public string Location
        {
            get
            {
              
               return _location;
            }
            set
            {

                CityOutput.Add(myVerbindung.getLocation(Location, CityOutput));
              
                _location = value;
                OnPropertyChanged();
            }
        }
        public async Task tuetwas()
        {
            await Task.Run(() => myVerbindung.getLocation(Location, CityOutput));
        
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

        private string _day1;
        public string Day1
        {
            get { return _day1; }
            set
            {
                _day1 = value;
                OnPropertyChanged();
            }
        }
        private string _day2;
        public string Day2
        {
            get { return _day2; }
            set
            {
                _day2 = value;
                OnPropertyChanged();
            }
        }
        private string _day3;
        public string Day3
        {
            get { return _day3; }
            set
            {
                _day3 = value;
                OnPropertyChanged();
            }
        }

        private string _day4;
        public string Day4
        {
            get { return _day4; }
            set
            {
                _day4 = value;
                OnPropertyChanged();
            }
        }

        private string _day5;
        public string Day5
        {
            get { return _day5; }
            set
            {
                _day5 = value;
                OnPropertyChanged();
            }
        }

        private string _icon1;
        public string Icon1
        {
            get { return _icon1; }
            set
            {
                _icon1 = value;
                OnPropertyChanged();
            }
        }
        private string _icon2;
        public string Icon2
        {
            get { return _icon2; }
            set
            {
                _icon2 = value;
                OnPropertyChanged();
            }
        }
        private string _icon3;
        public string Icon3
        {
            get { return _icon3; }
            set
            {
                _icon3 = value;
                OnPropertyChanged();
            }
        }
        private string _icon4;
        public string Icon4
        {
            get { return _icon4; }
            set
            {
                _icon4 = value;
                OnPropertyChanged();
            }
        }
        private string _icon5;
        public string Icon5
        {
            get { return _icon5; }
            set
            {
                _icon5 = value;
                OnPropertyChanged();
            }
        }

        private string _degree1;
        public string Degree1
        {
            get { return _degree1; }
            set
            {
                _degree1 = value;
                OnPropertyChanged();
            }
        }

        private string _degree2;
        public string Degree2
        {
            get { return _degree2; }
            set
            {
                _degree2 = value;
                OnPropertyChanged();
            }
        }

        private string _degree3;
        public string Degree3
        {
            get { return _degree3; }
            set
            {
                _degree3 = value;
                OnPropertyChanged();
            }
        }

        private string _degree4;
        public string Degree4
        {
            get { return _degree4; }
            set
            {
                _degree4 = value;
                OnPropertyChanged();
            }
        }

        private string _degree5;
        public string Degree5
        {
            get { return _degree5; }
            set
            {
                _degree5 = value;
                OnPropertyChanged();
            }
        }

        private string _description1;
        public string Description1
        {
            get { return _description1; }
            set
            {
                _description1 = value;
                OnPropertyChanged();
            }
        }
        private string _description2;
        public string Description2
        {
            get { return _description2; }
            set
            {
                _description2 = value;
                OnPropertyChanged();
            }
        }
        private string _description3;
        public string Description3
        {
            get { return _description3; }
            set
            {
                _description3 = value;
                OnPropertyChanged();
            }
        }
        private string _description4;
        public string Description4
        {
            get { return _description4; }
            set
            {
                _description4 = value;
                OnPropertyChanged();
            }
        }
        private string _description5;
        public string Description5
        {
            get { return _description5; }
            set
            {
                _description5 = value;
                OnPropertyChanged();
            }
        }

        private string _tempMax1;
        public string TempMax1
        {
            get { return _tempMax1; }
            set
            {
                _tempMax1 = value;
                OnPropertyChanged();
            }
        }

        private string _tempMax2;
        public string TempMax2
        {
            get { return _tempMax2; }
            set
            {
                _tempMax2 = value;
                OnPropertyChanged();
            }
        }

        private string _tempMax3;
        public string TempMax3
        {
            get { return _tempMax3; }
            set
            {
                _tempMax3 = value;
                OnPropertyChanged();
            }
        }
        private string _tempMax4;
        public string TempMax4
        {
            get { return _tempMax4; }
            set
            {
                _tempMax4 = value;
                OnPropertyChanged();
            }
        }

        private string _tempMax5;
        public string TempMax5
        {
            get { return _tempMax5; }
            set
            {
                _tempMax5 = value;
                OnPropertyChanged();
            }
        }
    }
}
