using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class RejectedCommandMatcher : CommandMatcher<RejectedCommand>
    {
        public RejectedCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^rejected (?<commandName>\w+)\s*$"),
                commandFactory)
        {
        }
    }
}
