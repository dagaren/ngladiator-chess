using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class GoCommandMatcher: CommandMatcher<GoCommand>
    {
        public GoCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^go\s*$"),
                commandFactory)
        {
        }
    }
}
