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
    public class ForecastService
    {
        private const string APP_ID = "df1b80f131e96328741e25b186b378ba";
        private HttpClient client;
        public ForecastModel model;

        public ForecastService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");

        }

        public ForecastModel GetForecast(string location)
        {
            var url = $"forecast?q={location}&units=metric&appid={APP_ID}";
            var request = WebRequest.Create(client.BaseAddress + url);
            System.IO.Stream responseStream;
            try
            {
                responseStream = request.GetResponse().GetResponseStream();
            }
            catch
            {
                throw new System.ArgumentException("City Not Found");
            }


            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                       model = new ForecastModel();

                        model = JsonConvert.DeserializeObject<ForecastModel>(streamReader.ReadLine());
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
