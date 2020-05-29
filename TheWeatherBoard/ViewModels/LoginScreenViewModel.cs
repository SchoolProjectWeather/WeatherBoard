using Caliburn.Micro;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Services;
using TheWeatherBoard.Views;

namespace TheWeatherBoard.ViewModels
{
   public class LoginScreenViewModel: ViewModelBase
    {
        LoginServiceSQL loginService = new LoginServiceSQL();
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        public RelayCommand<Window> RegisterCommand { get; private set; }



        public LoginScreenViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
            this.RegisterCommand = new RelayCommand<Window>(this.RegisterWindow);
        }
        private void RegisterWindow(Window window)
        {
            OpenRegisterPage();
            if (window != null)
            {
                window.Close();
            }
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        private void OpenRegisterPage()
        {
            RegisterScreen registerView = new RegisterScreen();
            registerView.Show();
            var loginScreen = (Application.Current.MainWindow as LoginScreen);
            if (loginScreen != null)
            {
                loginScreen.Close();
            }
            
        }
        /// <summary>
        /// Hier ein ohne Vererbung erstellter Command, da er einen Parameter der Oberflache bekommt
        /// </summary>
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    //LambdaExpression
                    _loginCommand = new RelayCommand<object>(i => Login(i));
                return _loginCommand;
            }
            set
            { 
            }
        }


        //Funktion für das Login
        private void Login(object obj)
        {
           //Passwort der Oberfläche wird hier erstellt da man es aus Sicherheitsgründen nicht binden kann
            PasswordBox pwBox = obj as PasswordBox;

           //Loginservice gefüllt mit Daten der Oberfläche wird abgefeuert:)
           loginService.BuildSqlConnection(Name, pwBox.Password);

        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {   //Handling für leeres Textfeld bei Name
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty!");
                } 
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
