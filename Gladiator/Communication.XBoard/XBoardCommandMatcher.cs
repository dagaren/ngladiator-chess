using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class XBoardCommandMatcher : CommandMatcher<XBoardCommand>
    {
        public XBoardCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^xboard\s*$"),
                commandFactory)
        {
        }
    }
}
