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
	  public static int userid;
	    
		public override void BuildSqlConnection(string userName, string password)
		{

			userName = AESEncryption.HashStringAes256(userName);
			password = AESEncryption.HashStringAes256(password);
			
			//in config
			string connectionString = "SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=36f*fSv§sSf-aa;";
			MySqlConnection connection = new MySqlConnection(connectionString);

			try
			{
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}

				string loginquery = "SELECT COUNT(1) FROM login WHERE userName=@userName AND Password=@Password";
				MySqlCommand sqlCommand = new MySqlCommand(loginquery, connection);
				sqlCommand.Parameters.AddWithValue("@userName", userName);
				sqlCommand.Parameters.AddWithValue("@Password", password);
				sqlCommand.CommandType = System.Data.CommandType.Text;
				int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

				string pkquery = "SELECT id FROM login WHERE userName=@userName AND Password=@Password";
				MySqlCommand getPKCommand = new MySqlCommand(pkquery, connection);
				getPKCommand.Parameters.AddWithValue("@userName", userName);
				getPKCommand.Parameters.AddWithValue("@Password", password);
				getPKCommand.CommandType = System.Data.CommandType.Text;
				userid = Convert.ToInt32(getPKCommand.ExecuteScalar());

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
