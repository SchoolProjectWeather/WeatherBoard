using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheWeatherBoard.Bases
{
    //Diese Klasse erbt von ICommand und dient als Basis zum erstellen von Commands
   public class ButtonCommandBase: ICommand
    {
        private Action _execute;
        public event EventHandler CanExecuteChanged;

            public ButtonCommandBase(Action execute)
            {
                _execute = execute;
            }

        public void Execute(object parameter)
            {
                _execute.Invoke();
               
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }
        }
    }

