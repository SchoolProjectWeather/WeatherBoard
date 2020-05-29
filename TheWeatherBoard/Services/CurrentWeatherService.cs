using Newtonsoft.Json;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheWeatherBoard.ErrorHandling;
using TheWeatherBoard.Models;
using System.Windows;

namespace TheWeatherBoard.Services
{
   public class CurrentWeatherService
    {
        private const string APP_ID = "df1b80f131e96328741e25b186b378ba";
        private HttpClient client;
        public CurrentWeatherModel model;

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
                throw new System.ArgumentException("City not found!");
            }
           
            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        model = new CurrentWeatherModel();
                        model = JsonConvert.DeserializeObject<CurrentWeatherModel>(streamReader.ReadLine());
                        return model;

                    }

                }
            }
            else
            {
                throw new System.ArgumentException("Invalid API key.");
            }

            throw new System.ArgumentException("Invalid API key.");
        }
        
        public void UpdateFavCity(string location, int primaryKey)
        {
            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");

            try
            {
                connection.Open();
                string updateQuery = $"UPDATE login SET city_name = '{location}' WHERE id = {primaryKey}";
                MySqlCommand myCommand = new MySqlCommand(updateQuery, connection);
                MySqlDataReader reader = myCommand.ExecuteReader();
                MessageBox.Show("Favoriten Stadt Erfolgreich hinzugefügt! Deine Favoriten Stadt wird beim nächsten Start initialisiert.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public string readFavCity()
        {
            string favcity = "";
            
            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");
            try
            {
                connection.Open();
                string insertQuery = "SELECT city_name FROM login WHERE id = " + LoginServiceSQL.userid.ToString();
                MySqlCommand myCommand = new MySqlCommand(insertQuery, connection);
                favcity = myCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return favcity;
        }
    }
}
