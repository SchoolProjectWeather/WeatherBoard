using OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherBoard.Helper;

namespace WeatherBoard.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public OpenWeatherApiService service = new OpenWeatherApiService();

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler tempHandler = PropertyChanged;
            if (tempHandler != null)
                tempHandler(this, new PropertyChangedEventArgs(propertyName));
        }

       public ButtonCommandBase ShowWeather { get; private set; }

        private string _temperature;

            public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        private string _cityInput;

        public string CityInput
        {
            get
            {
                return _cityInput;
            }
            set
            {
                _cityInput = value;
                OnPropertyChanged();
            }
        }


               private string _comment;

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment= value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ShowWeather = new ButtonCommandBase(GetWeather);
        }
       

        public async void GetWeather()
        {
            //double temperature =Convert.ToDouble( service.currentWeatherService(CityInput));
           // Output = temperature.ToString();
           //Output= service.currentWeatherService(CityInput);
           
           var client = new OpenWeatherMapClient("df1b80f131e96328741e25b186b378ba");
            try
            {
                var currentWeather = await client.CurrentWeather.GetByName($@"{CityInput}", MetricSystem.Metric, OpenWeatherMapLanguage.DE);
                Temperature = Convert.ToString(currentWeather.Temperature.Value) + "°C";
                Comment = Convert.ToString(currentWeather.Weather.Value);
                var info = Convert.ToString(currentWeather.Wind.Speed.Value);
                var info2 = Convert.ToString(currentWeather.Temperature.Min);

                //Temperature =Convert.ToString(service.currentWeatherService(CityInput));

               /// var forecast = await client.Forecast.GetByName($@"{CityInput}", true, MetricSystem.Metric, OpenWeatherMapLanguage.DE);

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
           
          

        }
    }
}
