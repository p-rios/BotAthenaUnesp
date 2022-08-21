using BotAthenaUnesp_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BotAthenaUnesp_Domain
{
    public class Encoder : IEncoder
    {


        public string Encrypt(string password)
        {

            var encoding = new UTF8Encoding();
            byte[] plain = encoding.GetBytes(password);
            byte[] secret = ProtectedData.Protect(plain, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(secret);

        }
        public string Decrypt(string encodedPassword)
        {

            byte[] secret = Convert.FromBase64String(encodedPassword);
            byte[] plain = ProtectedData.Unprotect(secret, null, DataProtectionScope.CurrentUser);
            var encoding = new UTF8Encoding();
            return encoding.GetString(plain);

        }
    }
}
