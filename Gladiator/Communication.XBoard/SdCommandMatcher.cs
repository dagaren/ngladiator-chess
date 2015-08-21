using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class SdCommandMatcher : CommandMatcher<SdCommand>
    {
        public SdCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^sd\s+(?<depth>\d+)\s*$"),
                commandFactory)
        {
        }
    }
}
