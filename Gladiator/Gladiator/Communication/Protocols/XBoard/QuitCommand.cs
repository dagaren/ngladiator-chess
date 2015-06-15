using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard
{
    class QuitCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Quit command received");
        }
    }
}
