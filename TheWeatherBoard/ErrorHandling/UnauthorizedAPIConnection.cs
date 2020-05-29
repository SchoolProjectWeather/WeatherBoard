using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.ErrorHandling
{
    /*Diese Klasse enthält namentlich angepasste Exceptions, die auf ArgumentExceptions basieren.
     * Diese konnten wir aber auf Grund des Zeitdrucks nichtmehr wirklich perfekt plazieren und benutzen
     * Exceptions die geworfen werden soll, sobald der API Key invalide ist
     */

    public class UnauthorizedAPIConnection : Exception
        {
            public UnauthorizedAPIConnection()
            {
            }

            public UnauthorizedAPIConnection(string message) : base(message)
            {
            }

            public UnauthorizedAPIConnection(string message, Exception inner) : base(message, inner)
            {
            }
        }
    
}
