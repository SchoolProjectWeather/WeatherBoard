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
        //Konstante API-Key, wird benötigt um den API-Call abzurufen
        private const string APP_ID = "df1b80f131e96328741e25b186b378ba";
        // Http Client wird für den Request benötigt
        private HttpClient client;
        //Dieses Model wird durch die gelieferte JSON der API beschrieben
        public CurrentWeatherModel model;

        public CurrentWeatherService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            
        }
        //diese Methode gibt ein CurrentWeatherModel zurück, für die gefilterte Stadt die per Parameter übergeben wird
        public CurrentWeatherModel GetCurrentWeather(string location)
        {
            //CurrentWeather Api-string
            var url = $"weather?q={location}&units=metric&appid={APP_ID}";
            var request = WebRequest.Create(client.BaseAddress + url);
            System.IO.Stream responseStream;
            try
            {
                 responseStream = request.GetResponse().GetResponseStream();
            }
            catch
            {   //Falls der Parameter eine falsche Stadt bekommt, fogt ExceptionHandling
                throw new System.ArgumentException("City not found!");
            }
           
            if (responseStream != null)
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        //Json wird deserialisiert und in die Properties des Models geschrieben
                        model = new CurrentWeatherModel();
                        model = JsonConvert.DeserializeObject<CurrentWeatherModel>(streamReader.ReadLine());
                        //return der models
                        return model;

                    }

                }
            }
            else
            {// Exceptions, falls der API-Key ungültig wird
                throw new System.ArgumentException("Invalid API key.");
            }

            throw new System.ArgumentException("Invalid API key.");
        }
        
        public void UpdateFavCity(string location, int primaryKey)
        {/*SQL Connection, auslagerung aus zeitlichen Gründen jetzt nichtmehr möglich:(
           */
            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");

            try
            {//Öffnen der Connection
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
                //Im finally block wird die Connection geschlossen
                connection.Close();
            }
        }

        /// <summary>
        /// Diese Funktion sollte eigentlich noch ausgelagert werden, sie sorgt dafür das die favosisierte Stadt eines Benutzers
        /// in seinen Account gespeichert wird
        /// </summary>
        /// <returns>favcity (string)</returns>
        public string readFavCity()
        {
            //inital variable für favorite Stadt
            string favcity = "Stuttgart";
            //Connection für db
            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");
            try
            {   //öffnen der Verbindung
                connection.Open();
                //query für die Verbindung mit dem Benutzer
                string insertQuery = "SELECT city_name FROM login WHERE id = " + LoginServiceSQL.userid.ToString();
                MySqlCommand myCommand = new MySqlCommand(insertQuery, connection);
                //Schreiben der Favoritenstadt in die Vairable
                favcity = myCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {   //Errorhandling
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
