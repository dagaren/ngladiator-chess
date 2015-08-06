using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gladiator.Communication
{
    internal class ConsoleCommandReader : ICommandReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
