using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheWeatherBoard.Views;

namespace TheWeatherBoard.Services
{
  public class LoginServiceSQL: ServicesSQL
    {
		public override void BuildSqlConnection(string name, string password)
		{

			name = AESEncryption.HashStringAes256(name);
			password = AESEncryption.HashStringAes256(password);
			//in config
			string connectionString = "SERVER=127.0.0.1;Port=3306;DATABASE=mydb;UID=root;Pwd=root;";
			MySqlConnection connection = new MySqlConnection(connectionString);

			try
			{
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}

				string query = "SELECT COUNT(1) FROM users WHERE name=@name AND password=@password";
				MySqlCommand sqlCommand = new MySqlCommand(query, connection);
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.Parameters.AddWithValue("@name", name);
				sqlCommand.Parameters.AddWithValue("@password", password);

				int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

				if (count == 1)
				{
					MainView2 mainView = new MainView2();
					mainView.Show();

					var loginScreen = (Application.Current.MainWindow as LoginScreen);
					if (loginScreen != null)
					{
						loginScreen.Close();
					}
				}
				else
				{
					MessageBox.Show("Incorrect Password or incorrect Username, please check!");
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);

			}
			finally
			{
				connection.Close();
		
			}
		}
	}
}
