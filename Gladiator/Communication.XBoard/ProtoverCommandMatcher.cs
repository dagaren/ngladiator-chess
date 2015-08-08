using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class ProtoverCommandMatcher : CommandMatcher<ProtoverCommand>
    {
        public ProtoverCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^protover (?<version>\d)$"),
                commandFactory)
        {
        }
    }
}
