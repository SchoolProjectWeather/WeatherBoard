using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.ErrorHandling
{
  

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
