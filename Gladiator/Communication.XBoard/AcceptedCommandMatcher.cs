using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class AcceptedCommandMatcher : CommandMatcher<AcceptedCommand>
    {
        public AcceptedCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^accepted (?<commandName>\w+)\s*$"),
                commandFactory)
        {
        }
    }
}
