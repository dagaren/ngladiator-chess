using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    internal class ConsoleCommandWriter : ICommandWriter
    {
        public void Write(string command)
        {
            Console.WriteLine(command);
        }
    }
}
