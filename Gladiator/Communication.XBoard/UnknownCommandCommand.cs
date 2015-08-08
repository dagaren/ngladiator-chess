using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class UnknownCommandCommand : ICommand
    {
        private const string ErrorReason = "Unknown command";

        private Action<string, string> errorAction;

        private string command;

        public UnknownCommandCommand(Action<string, string> errorAction, string command)
        {
            Check.ArgumentNotNull(errorAction, "errorAction");

            this.errorAction = errorAction;
            this.command = command;
        }

        public void Execute()
        {
            this.errorAction(ErrorReason, command);
        }
    }
}
