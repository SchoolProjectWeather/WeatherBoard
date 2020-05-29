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
	//Klasser erbt von der Abstrakten ServiceSQL Klasse welche die BuildSQLConnection beinhaltet
  public class LoginServiceSQL: ServicesSQL
  {
	  public static int userid;
	    
		//Verwendung von ovverride
		public override void BuildSqlConnection(string userName, string password)
		{
			//Verschlüsseln von Usernamen und Passwort
			userName = AESEncryption.HashStringAes256(userName);
			password = AESEncryption.HashStringAes256(password);
			
			//SQL Connection String wird von der Abstrakten Klasse ServicesSQL verwendet
			string connectionString = ServicesSQL.connectionString;
			//neue connection
			MySqlConnection connection = new MySqlConnection(connectionString);

			try
			{
				//abfrage ob connection zu ist, wenn ja öffnen
				if (connection.State == ConnectionState.Closed)
				{
					connection.Open();
				}
				//query für den Login, userdaten dürfen nur einmal vorkommen
				string loginquery = "SELECT COUNT(1) FROM login WHERE userName=@userName AND Password=@Password";
				MySqlCommand sqlCommand = new MySqlCommand(loginquery, connection);
				sqlCommand.Parameters.AddWithValue("@userName", userName);
				sqlCommand.Parameters.AddWithValue("@Password", password);
				sqlCommand.CommandType = System.Data.CommandType.Text;
				int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
				//Filterung über einen identifizierbarendatensatz über PrimaryKey
				string pkquery = "SELECT id FROM login WHERE userName=@userName AND Password=@Password";
				MySqlCommand getPKCommand = new MySqlCommand(pkquery, connection);
				getPKCommand.Parameters.AddWithValue("@userName", userName);
				getPKCommand.Parameters.AddWithValue("@Password", password);
				getPKCommand.CommandType = System.Data.CommandType.Text;
				userid = Convert.ToInt32(getPKCommand.ExecuteScalar());

				if (count == 1)
				{	//Öffnen des Hauptfensters bei erfolgreichem einlogggen
					MainView2 mainView = new MainView2();
					mainView.Show();
					//im anschluss schließen des Loginscreens
					var loginScreen = (Application.Current.MainWindow as LoginScreen);
					if (loginScreen != null)
					{
						loginScreen.Close();
					}
				}
				else
				{	//error Handling
					MessageBox.Show("Incorrect Password or incorrect Username, please check!");
				}
			}
			catch (Exception ex)
			{
				//error Handling
				MessageBox.Show(ex.Message);

			}
			finally
			{
				//letzendelich Schließen der Connection
				connection.Close();
		
			}
		}
	}
}
