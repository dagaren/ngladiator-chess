using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class MoveNowCommandMatcher : CommandMatcher<MoveNowCommand>
    {
        public MoveNowCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^\?\s*$"),
                commandFactory)
        {
        }
    }
}
