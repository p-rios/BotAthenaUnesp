using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotAthenaUnesp_Domain.Interfaces
{
    public interface IEncoder
    {
        string Encrypt(string password);
        string Decrypt(string encodedPassword);
    }
}
