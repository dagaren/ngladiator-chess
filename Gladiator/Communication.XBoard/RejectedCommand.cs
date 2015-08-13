using System;

namespace Gladiator.Communication.XBoard
{
    public class RejectedCommand : ICommand
    {
        private string commandName;

        public RejectedCommand(string commandName)
        {
            this.commandName = commandName;
        }

        public void Execute()
        {
            // Do nothing
        }
    }
}
