using Gladiator.Utils;
using System;

namespace Gladiator.Communication.Protocols.XBoard
{
    class QuitCommand : ICommand
    {
        private Action quitAction;

        public QuitCommand(Action quitAction)
        {
            Check.ArgumentNotNull(quitAction, "quitAction");

            this.quitAction = quitAction;
        }

        public void Execute()
        {
            this.quitAction();
        }
    }
}
