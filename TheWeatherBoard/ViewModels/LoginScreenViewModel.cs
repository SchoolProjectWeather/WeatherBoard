using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
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
        
       

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand<object>(i => Login(i));
                return _loginCommand;
            }
        }



        private void Login(object obj)
        {

            PasswordBox pwBox = obj as PasswordBox;

            loginService.BuildSqlConnection(Name, pwBox.Password);
            
           

           
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
