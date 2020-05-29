using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Services
{
    //Abstrakte Klasse für die Benutzerverwaltung der Datenbank
   public abstract class ServicesSQL
    { //Übergebene Connection für die Nutzerverwaltung
        protected static string connectionString = "SERVER=127.0.0.1;Port=3306;DATABASE=weatherdisplay_db;UID=root;Pwd=root;";
       //Abstrakte Methode für Benutzerverwaltung
       /// <summary>
       /// Wird für Nutzerverwaltung vererbt
       /// </summary>
       /// <param name="username"></param>
       /// <param name="password"></param>
        public abstract void BuildSqlConnection(string username, string password);
    }
}
