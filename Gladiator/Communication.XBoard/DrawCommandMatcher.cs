using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class DrawCommandMatcher : CommandMatcher<DrawCommand>
    {
        public DrawCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^draw\s*$"),
                commandFactory)
        {
        }
    }
}
