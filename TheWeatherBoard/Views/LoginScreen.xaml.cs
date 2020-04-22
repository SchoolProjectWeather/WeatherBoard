using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheWeatherBoard.Services;

namespace TheWeatherBoard.Views
{
	/// <summary>
	/// Interaktionslogik für LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Window
	{
		public bool magic;
		public LoginScreen()
		{
			InitializeComponent();
		}

		LoginServiceSQL loginService = new LoginServiceSQL();

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//loginService.BuildSqlConnection(tbUsername.Text, pbPassword.Password, magic);
			//this.Close();

				string connectionString = @"Server=127.0.0.1,3306;Database=Login;User Id=root;Password=root;";
				MySqlConnection connection = new MySqlConnection(connectionString);

				try
				{
					if (connection.State == ConnectionState.Closed)
					{
						connection.Open();
					}

					string query = "SELECT COUNT(1) FROM user WHERE userName=@userName AND Password=@Password";
					MySqlCommand sqlCommand = new MySqlCommand(query, connection);
					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.Parameters.AddWithValue("@userName", tbUsername.Text);
					sqlCommand.Parameters.AddWithValue("@Password", pbPassword.Password);

					int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

					if (count == 1)
					{
						MainView2 mainView = new MainView2();
						mainView.Show();
						this.Close();


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

