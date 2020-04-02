using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TheWeatherBoard.Bases;
using TheWeatherBoard.Views;

namespace TheWeatherBoard.ViewModels
{
   public class LoginScreenViewModel: ViewModelBase
    {
        public ButtonCommandBase LoginCommand { get; private set; }

        public LoginScreenViewModel()
        {
            LoginCommand = new ButtonCommandBase(Login);
        }

        private void Login()
        {
         

        
        }
    }
}
