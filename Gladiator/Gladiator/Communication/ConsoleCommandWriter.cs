using Gladiator.Utils;
using System;

namespace Gladiator.Communication
{
    internal class ConsoleCommandWriter : ICommandWriter
    {
        public void Write(string command)
        {
            ConsoleExtensions.WriteLineColoured(command, ConsoleColor.Red);
        }
    }
}
