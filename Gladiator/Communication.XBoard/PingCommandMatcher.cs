using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class PingCommandMatcher : CommandMatcher<PingCommand>
    {
        public PingCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^ping\s+(?<number>\d+)\s*$"),
                commandFactory)
        {
        }
    }
}
