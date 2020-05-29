using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Services
{
    //Diese Klasse ist für sämtliche Verschlüsselungen zuständig
    public static class AESEncryption
    {
        /*Diese Funktion kann strings nach Aes256 verschlüsseln, die Methode wird zur Verschlüsselungen von Benutzedaten verwendet, für erhöhte Sichertheit
         */
        public static string HashStringAes256(string value)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                //String wird in Bytes geteilt und gehasht
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));
                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            //Return des verschlüsselten Strings
            return Sb.ToString();
        }

    }
}
