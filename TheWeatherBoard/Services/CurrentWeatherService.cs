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

            //request stuff
            
            

            var url = $"weather?q={location}&units=metric&appid={APP_ID}";


            var request = WebRequest.Create(client.BaseAddress + url);

           
            var responseStream = request.GetResponse().GetResponseStream();

            
            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        //System.IO.File.WriteAllText(@"C:\Users\diz\Desktop\test.txt", streamReader.ReadLine());


                        var model = new Models.CurrentWeatherModel();
                        model = JsonConvert.DeserializeObject<CurrentWeatherModel>(streamReader.ReadLine());


                        //MessageBox.Show(model.name);
                        //MessageBox.Show(model.main.temp);


                        //MessageBox.Show(model.weather[0].description);

                        //double test = double.Parse(model.main.temp);
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
