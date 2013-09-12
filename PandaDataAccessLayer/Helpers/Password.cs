using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Helpers
{
    public static class Password
    {
        public static string MakePassword(string password, DateTime createdOn)
        {
            var dtString = createdOn.ToString("yyyyddmm");
            return Crypt.GetMD5Hash(password + dtString);
        }
    }
}
