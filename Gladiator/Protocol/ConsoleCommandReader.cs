namespace Dagaren.Gladiator.Protocol
{
    using System;

    class ConsoleCommandReader : ICommandReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
