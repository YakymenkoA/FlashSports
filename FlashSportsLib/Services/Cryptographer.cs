using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlashSportsLib.Services
{
    public class Cryptographer
    {
        public static string GetHash(string pass)
        {
            string result = string.Empty;
            MD5 md5 = MD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(pass);
            byte[] hash = md5.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            result = sb.ToString();
            return result;
        }
    }
}
