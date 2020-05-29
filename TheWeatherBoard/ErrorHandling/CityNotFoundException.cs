using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.ErrorHandling
{
   /*Diese Klasse enthält namentlich angepasste Exceptions, die auf ArgumentExceptions basieren.
    * Diese konnten wir aber auf Grund des Zeitdrucks nichtmehr wirklich perfekt plazieren und benutzen
    */
        public class ArgumentException : Exception
        {
            public ArgumentException()
            {
            }

            public ArgumentException(string message) : base(message)
            {
            }

            public ArgumentException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    
}
