using System;

namespace Gladiator.Communication.Protocols.XBoard
{
    class ProtoverCommand : ICommand
    {
        private int version;

        public ProtoverCommand(int version)
        {
            this.version = version;
        }

        public void Execute()
        {
            Console.WriteLine("Protover. Version: " + version);
        }
    }
}
