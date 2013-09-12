using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Helpers
{
    public class Crypt
    {
        public static string GetMD5Hash(string data)
        {
            var md5Hasher = MD5.Create();
            var hashBytes = md5Hasher.ComputeHash(data.GetBytes());

            var result = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                result.Append(hashBytes[i].ToString());
            }
            return result.ToString();
        }
    }
}
