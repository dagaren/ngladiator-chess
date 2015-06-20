using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols
{
    public interface IProtocol
    {
        void ProcessCommand(string commandString);
    }
}
