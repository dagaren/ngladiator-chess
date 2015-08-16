using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class PlayOtherCommandMatcher : CommandMatcher<PlayOtherCommand>
    {
        public PlayOtherCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^playother\s*$"),
                commandFactory)
        {
        }
    }
}
