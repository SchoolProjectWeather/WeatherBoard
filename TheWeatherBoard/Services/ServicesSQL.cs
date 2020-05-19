using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Services
{
   public abstract class ServicesSQL
    {

        public abstract void BuildSqlConnection(string username, string password);
    }
}
