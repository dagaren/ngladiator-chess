using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    class NotificableCommand : ICommand
    {
        private ICommand innerCommand;

        private Action notifyAction;

        public NotificableCommand(ICommand innerCommand, Action notifyAction)
        {
            if(innerCommand == null)
            {
                throw new ArgumentNullException("innerCommand");
            }

            if(notifyAction == null)
            {
                throw new ArgumentNullException("notifyAction");
            }

            this.innerCommand = innerCommand;
            this.notifyAction = notifyAction;
        }

        public void Execute()
        {
            this.innerCommand.Execute();

            this.notifyAction();
        }
    }
}
