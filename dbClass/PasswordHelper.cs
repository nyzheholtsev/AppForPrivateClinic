using System;
using System.Security.Cryptography;
using System.Text;

namespace program.dbClass
{
    
    public static class PasswordHelper
    {
        public static string ComputeHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create()) //инициализирую
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password); 
                byte[] hash = sha256.ComputeHash(bytes); //конверт 

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2")); // x2 = 16 с 2 символами
                }
                return builder.ToString();
            }
        }
    }
}
