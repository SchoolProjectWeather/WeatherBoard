using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheWeatherBoard.Services
{
    public class RegisterServiceSQL : ServicesSQL
    {
        public override void BuildSqlConnection(string username, string password)
        {

           username= AESEncryption.HashStringAes256(username);
           password = AESEncryption.HashStringAes256(password);

            MySqlConnection connection = new MySqlConnection("SERVER=127.0.0.1;Port=3306;DATABASE=city;UID=root;Pwd=root;");
            connection.Open();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                //Alle Datensätze aus der DB holen per SQL-Befehl.
                string mySelectQuery = $@"INSERT INTO `city`.`login` (`userName`,`Password`,`city_id`) VALUES ('{username}','{password}','49593');";
                MySqlCommand myCommand = new MySqlCommand(mySelectQuery, connection);
                MySqlDataReader Reader = myCommand.ExecuteReader();
            }
            catch {

                throw new ArgumentException("Fehler....");

            }
            finally
            {
                connection.Close();
            }
        }
    }
}