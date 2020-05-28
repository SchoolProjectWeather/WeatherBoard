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

           username= AESEncryption.HashStringAes256(username);
           password = AESEncryption.HashStringAes256(password);

            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;");
            connection.Open();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string mySelectQuery = $@"INSERT INTO `weatherdisplay_db`.`login` (`userName`,`Password`,`city_id`) VALUES ('{username}','{password}','49593');";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, connection);
                MySqlDataReader Reader = myCommand.ExecuteReader();
                var registerScreen = (Application.Current.MainWindow as RegisterScreen);

                if (registerScreen != null)
                {
                    registerScreen.Close();
                }
            }

            catch
            {

                throw new ArgumentException("Fehler....");

            }
            finally
            {
                connection.Close();
            }
        }
    }
}