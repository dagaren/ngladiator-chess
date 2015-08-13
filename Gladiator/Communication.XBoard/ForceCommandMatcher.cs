using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class ForceCommandMatcher : CommandMatcher<XBoardCommand>
    {
        public ForceCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^force\s*$"),
                commandFactory)
        {
        }
    }
}
