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
		public override void BuildSqlConnection(string userName, string password)
		{

			userName = AESEncryption.HashStringAes256(userName);
			password = AESEncryption.HashStringAes256(password);
			MySqlConnection connection = new MySqlConnection(ServicesSQL.connectionString);
		
			try
			{
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}

				string query = "SELECT COUNT(1) FROM login WHERE userName=@userName AND Password=@Password";
				MySqlCommand sqlCommand = new MySqlCommand(query, connection);
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.Parameters.AddWithValue("@userName", userName);
				sqlCommand.Parameters.AddWithValue("@Password", password);

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
