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
            if(commandFactory == null)
            {
                throw new ArgumentNullException("commandFactory");
            }

            this.commandMatchers = new List<ICommandMatcher<ICommand>>();

            this.FillCommandMatchers();
        }

        public void ProcessCommand(string commandString)
        {
            foreach (var commandMatcher in this.commandMatchers)
            {
                ICommand command = commandMatcher.Match(commandString);

                if (command != null)
                {
                    command.Execute();
                    return;
                }
            }

            throw new ArgumentException(string.Format("Command '{0}' not found", commandString));
        }

        private void FillCommandMatchers()
        {
            this.commandMatchers.Add(new XBoardCommandMatcher(this.commandFactory));
            this.commandMatchers.Add(new QuitCommandMatcher(this.commandFactory));
        }
    }
}
