using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotAthenaUnesp_Domain.Interfaces
{
    public interface IDocWriter
    {
        public void CreateData();
        public Data Read();

    }
}
