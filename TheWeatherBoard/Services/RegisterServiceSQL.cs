using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TheWeatherBoard.Views;

namespace TheWeatherBoard.Services
{
    public class RegisterServiceSQL : ServicesSQL
    {
        public override void BuildSqlConnection(string username, string password)
        {
            //Verschlüsseln von Usernamen und Passwort
            username = AESEncryption.HashStringAes256(username);
           password = AESEncryption.HashStringAes256(password);

            //SQL Connection String wird von der Abstrakten Klasse ServicesSQL verwendet
            MySqlConnection connection = new MySqlConnection(ServicesSQL.connectionString);
            connection.Open();

            try
            {   //abfrage ob connection zu ist, wenn ja öffnen
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                //Prüfen ob ein gleicher Datensatz bei der Registrierung schon verhanden ist
                string checkQuery = $"SELECT COUNT(1) FROM login WHERE userName='{username}'";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@userName", username);
                checkCommand.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count >= 1)
                {   //Falls Nutzername vorhanden ist Handling
                    MessageBox.Show("Dein Nutzername ist schon vergeben, wähle bitte einen anderen und Versuche es erneut.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                else if (count == 0)
                {
                    //Query für das Speichern des neuen Nutzers
                    string mySelectQuery = $@"INSERT INTO `weatherdisplay_db`.`login` (`userName`,`Password`,`city_name`) VALUES ('{username}','{password}','Stuttgart');";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, connection);
                    MySqlDataReader Reader = myCommand.ExecuteReader();
                    MessageBox.Show("Erfolgreich registiert!", "Registriert", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

            catch
            {
                //ErrorHandling
                throw new ArgumentException("Fehler Connection");

            }
            finally
            {   //Schließen der Connection
                connection.Close();
            }
        }
    }
}