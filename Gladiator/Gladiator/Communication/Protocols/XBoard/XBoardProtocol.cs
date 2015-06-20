using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardProtocol : IProtocol
    {
        private ICollection<ICommandMatcher<ICommand>> commandMatchers;

        private ICommandFactory commandFactory;

        public XBoardProtocol(ICommandFactory commandFactory)
        {
            Check.ArgumentNotNull(commandFactory, "commandFactory");

            this.commandFactory = commandFactory;

            this.commandMatchers = new List<ICommandMatcher<ICommand>>();

            this.PopulateCommandMatchers();
        }

        public void ProcessCommand(string commandString)
        {
            foreach(ICommandMatcher<ICommand> commandMatcher in this.commandMatchers)
            {
                ICommand command = commandMatcher.Match(commandString);

                if(command != null)
                {
                    command.Execute();

                    return;
                }
            }

            throw new ArgumentException(string.Format("Command '{0}' not found", commandString));
        }

        private void PopulateCommandMatchers()
        {
            this.commandMatchers.Add(new XBoardCommandMatcher(this.commandFactory));
        }
    }
}
