using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class NewCommandMatcher : CommandMatcher<NewCommand>
    {
        public NewCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^new\s*$"),
                commandFactory)
        {
        }
    }
}
