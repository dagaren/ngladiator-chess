using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("XBoard command received");
        }
    }
}
