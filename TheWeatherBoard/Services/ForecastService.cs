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
        //Konstante API-Key, wird benötigt um den API-Call abzurufen
        private const string APP_ID = "df1b80f131e96328741e25b186b378ba";
        // Http Client wird für den Request benötigt
        private HttpClient client;
        //Dieses Model wird durch die gelieferte JSON der API beschrieben
        public ForecastModel model;

        public ForecastService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");

        }
        /// <summary>
        /// Diese Funktion bekommt eine Stadt übergeben und schickt einen ApiCall ab, bekommst anschließend
        /// ein JSON File zurück, welches in ein ForecastModel geschrieben und returned wird
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public ForecastModel GetForecast(string location)
        {   //Api Call (URL) für den Forecast
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
                        //Model wird deserialisiert und beschrieben
                        model = JsonConvert.DeserializeObject<ForecastModel>(streamReader.ReadLine());
                        return model;
                    }

                }
            }
            else
            {   //Errorhandling
                throw new UnauthorizedAPIConnection("Invalid API key.");
            }
            //Errorhandling
            throw new UnauthorizedAPIConnection("Invalid API key.");

        }
    }
}
