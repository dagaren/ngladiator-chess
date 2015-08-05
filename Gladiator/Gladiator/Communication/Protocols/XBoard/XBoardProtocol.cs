using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardProtocol : IProtocol
    {
        private List<ICommandMatcher<ICommand>> commandMatchers;

        public XBoardProtocol(IEnumerable<ICommandMatcher<ICommand>> commandMatchers)
        {
            Check.ArgumentNotNull(commandMatchers, "commandMatchers");

            this.commandMatchers = new List<ICommandMatcher<ICommand>>();
            this.commandMatchers.AddRange(commandMatchers);
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
    }
}
