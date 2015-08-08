using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.Protocols.XBoard
{
    class UnknownCommandCommandMatcher : CommandMatcher<UnknownCommandCommand>
    {
        public UnknownCommandCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"(?<command>.*)"),
                commandFactory)   
        {
        }
    }
}
