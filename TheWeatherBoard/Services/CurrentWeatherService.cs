using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheWeatherBoard.ErrorHandling;
using TheWeatherBoard.Models;

namespace TheWeatherBoard.Services
{
   public class CurrentWeatherService
    {
        private const string APP_ID = "df1b80f131e96328741e25b186b378ba";
        private HttpClient client;

        public CurrentWeatherService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
        }
   

        
        
        public CurrentWeatherModel GetCurrentWeather(string location)
        {
            var url = $"weather?q={location}&units=metric&appid={APP_ID}";
            var request = WebRequest.Create(client.BaseAddress + url);
            System.IO.Stream responseStream;
            try
            {
                 responseStream = request.GetResponse().GetResponseStream();
            }
            catch
            {
                throw new CityNotFoundException("City not found!");
            }
           
            
            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        var model = new Models.CurrentWeatherModel();
                        model = JsonConvert.DeserializeObject<CurrentWeatherModel>(streamReader.ReadLine());
                        return model;

                    }

                }
            }
            else
            {
                throw new UnauthorizedAPIConnection("Invalid API key.");
            }
                throw new UnauthorizedAPIConnection("Invalid API key.");

        }


    }
}
