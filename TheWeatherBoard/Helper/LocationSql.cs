using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheWeatherBoard.Services;
using TheWeatherBoard.ViewModels;

namespace TheWeatherBoard.Helper
{
    
    public class LocationSql
    {
       // MainViewModel hallo = new MainViewModel();
        public  string getLocation(string eingabe, ObservableCollection<string>cityOutput)
        {
            string anfang = eingabe + "%";

            if (!String.IsNullOrEmpty(eingabe))
            {
                try
                {
                    MySqlConnection myConnection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=36f*fSv§sSf-aa;");
                    myConnection.Open();
                    //Alle Datensätze aus der DB holen per SQL-Befehl.
                    string mySelectQuery = @"SELECT name FROM  `city` where (name Like '" + anfang + "') ORDER BY name Limit 8";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                    MySqlDataReader Reader = myCommand.ExecuteReader();
                    
                    cityOutput.Clear();

                    while (Reader.Read())
                    {
                       cityOutput.Add( Reader.GetValue(0).ToString());  
                    }
                    //Verbindung zur Datenbank wieder abbauen.
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
    }
}
