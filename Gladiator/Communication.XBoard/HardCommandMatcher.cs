using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class HardCommandMatcher : CommandMatcher<HardCommand>
    {
        public HardCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^hard\s*$"),
                commandFactory)
        {
        }
    }
}
