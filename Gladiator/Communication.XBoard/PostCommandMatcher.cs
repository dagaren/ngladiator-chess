using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class PostCommandMatcher : CommandMatcher<PostCommand>
    {
        public PostCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^post\s*$"),
                commandFactory)
        {
        }
    }
}
