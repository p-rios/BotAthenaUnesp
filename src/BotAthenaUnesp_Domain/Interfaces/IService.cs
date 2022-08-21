using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotAthenaUnesp_Domain.Interfaces
{
    public interface IService
    {
        sbyte Execute(string login, string senha);

    }
}
