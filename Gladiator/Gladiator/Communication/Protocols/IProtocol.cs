using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols
{
    interface IProtocol
    {
        void ProcessCommand(string commandString);
    }
}
