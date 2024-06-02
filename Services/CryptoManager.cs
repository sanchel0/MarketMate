using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Services
{
    public static class CryptoManager
    {
        /*public static string Encrypt(string pText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(pText));
        }

        public static string Decrypt(string pText)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(pText));
        }*/

        public static string HashPassword(string pPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pPassword));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
