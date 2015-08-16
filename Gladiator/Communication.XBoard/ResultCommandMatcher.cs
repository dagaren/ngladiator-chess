using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class ResultCommandMatcher : CommandMatcher<ResultCommand>
    {
        public ResultCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^result (?<result>.+?)(\s+(?<comment>.+?))?\s*$"),
                commandFactory)
        {
        }
    }
}
