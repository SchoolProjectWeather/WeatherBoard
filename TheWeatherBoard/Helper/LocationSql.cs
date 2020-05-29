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
       //Diese Funktion greift auf die Datenbank der Städte zu und passt die in eine Liste hinzugefügten Daten je nach Eingabe on the fly an
        public  string getLocation(string eingabe, ObservableCollection<string>cityOutput)
        {
            string anfang = eingabe + "%";

            if (!String.IsNullOrEmpty(eingabe))
            {
                try
                {   ///SQL-Connection aufbauen
                    MySqlConnection myConnection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");
                    myConnection.Open();
                    //Alle Datensätze aus der DB holen per SQL-Befehl.
                    string mySelectQuery = @"SELECT name FROM  `city` where (name Like '" + anfang + "') ORDER BY name Limit 8";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection);
                    MySqlDataReader Reader = myCommand.ExecuteReader();
                    
                    cityOutput.Clear();

                    while (Reader.Read())
                    {  //Hier werden die Werte der Datenbank in eine Observable Collection hinzugefügt
                       cityOutput.Add( Reader.GetValue(0).ToString());  
                    }
                    //Verbindung zur Datenbank wieder abbauen.
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    //Falls es Fehler in der Datenbank / Connection gibt, wird dies per MessageBox ausgegeben
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
    }
}
