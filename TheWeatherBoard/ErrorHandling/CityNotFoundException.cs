using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.ErrorHandling
{
   
        public class CityNotFoundException : Exception
        {
            public CityNotFoundException()
            {
            }

            public CityNotFoundException(string message) : base(message)
            {
            }

            public CityNotFoundException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    
}
