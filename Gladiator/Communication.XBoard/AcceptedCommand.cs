using System;

namespace Gladiator.Communication.XBoard
{
    public class AcceptedCommand : ICommand
    {
        private string commandName;

        public AcceptedCommand(string commandName)
        {
            this.commandName = commandName;
        }

        public void Execute()
        {
            // Do nothing
        }
    }
}
