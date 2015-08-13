using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class RandomCommandMatcher : CommandMatcher<RandomCommand>
    {
        public RandomCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^random\s*$"),
                commandFactory)
        {
        }
    }
}
