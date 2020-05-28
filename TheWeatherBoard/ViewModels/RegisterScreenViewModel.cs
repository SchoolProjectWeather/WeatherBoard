using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Helper;
using TheWeatherBoard.Services;
using TheWeatherBoard.Views;

namespace TheWeatherBoard.ViewModels
{
    public class RegisterScreenViewModel : ViewModelBase
    {
        RegisterServiceSQL registerService = new RegisterServiceSQL();

        private string _registerName;
        public string RegisterName
        {
            get { return _registerName; }
            set
            {
                _registerName = value;
                OnPropertyChanged();
            }
        }

        private ICommand _registerCommand;
        public ICommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null)
                    _registerCommand = new RelayCommand<object>(i => Registration(i));
                return _registerCommand;
            }
            set
            {


            }
        }

        private async void Registration(object obj)
        {
            PasswordBox pwBox = obj as PasswordBox;

            if (RegisterName == null || pwBox.Password.Length <= 0)
            {
                MessageBox.Show("Bitte beide Felder ausfüllen");
            }
            else
            {
                try
                {

                    await Task.Run(() => registerService.BuildSqlConnection(RegisterName, pwBox.Password));
                    LoginScreen loginView = new LoginScreen();
                    loginView.Show();

                }
                catch
                {
                    throw new ArgumentException("Registrierung fehlgeschlagen!");
                }

            }

            //SQL Inser-Befehl
            // throw new NotImplementedException();
        }
    }
}

