using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            var md5Hash = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5Hash.ComputeHash(inputBytes);
                
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
                
            return sb.ToString();
        }
    }
}