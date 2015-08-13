using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class NoPostCommandMatcher : CommandMatcher<NoPostCommand>
    {
        public NoPostCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^nopost\s*$"),
                commandFactory)
        {
        }
    }
}
