﻿using MySql.Data.MySqlClient;
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

            MySqlConnection connection = new MySqlConnection(ServicesSQL.connectionString);
            connection.Open();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string checkQuery = $"SELECT COUNT(1) FROM login WHERE userName='{username}'";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@userName", username);
                checkCommand.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count >= 1)
                {
                    MessageBox.Show("Dein Nutzername ist schon vergeben, wähle bitte einen anderen und Versuche es erneut.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                else if (count == 0)
                {
                    string mySelectQuery = $@"INSERT INTO `weatherdisplay_db`.`login` (`userName`,`Password`,`city_name`) VALUES ('{username}','{password}','Stuttgart');";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, connection);
                    MySqlDataReader Reader = myCommand.ExecuteReader();
                    MessageBox.Show("Erfolgreich registiert!", "Registriert", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
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