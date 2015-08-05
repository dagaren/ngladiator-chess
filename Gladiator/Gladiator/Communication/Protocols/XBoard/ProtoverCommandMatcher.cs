using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.Protocols.XBoard
{
    class ProtoverCommandMatcher : CommandMatcher<ProtoverCommand>
    {
        public ProtoverCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^protover (?<version>\d)$"),
                commandFactory)
        {
        }
    }
}
