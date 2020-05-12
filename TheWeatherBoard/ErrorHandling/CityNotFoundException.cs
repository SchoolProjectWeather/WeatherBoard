using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.ErrorHandling
{
   
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
