using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.Protocols.XBoard
{
    class QuitCommandMatcher : CommandMatcher<QuitCommand>
    {
        public QuitCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^quit\s*$"),
                commandFactory)   
        {
        }
    }
}
