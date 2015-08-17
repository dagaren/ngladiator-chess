using Gladiator.Utils;
using System;

namespace Gladiator.Communication
{
    public class ConsoleCommandWriter : ICommandWriter
    {
        public void Write(string command)
        {
            ConsoleExtensions.WriteLineColoured(command, ConsoleColor.Green);
        }
    }
}
