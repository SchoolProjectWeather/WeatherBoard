using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Services
{
   public abstract class ServicesSQL
    {
        protected static string connectionString = "SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;";
        public abstract void BuildSqlConnection(string username, string password);
    }
}
