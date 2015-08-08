using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class QuitCommandMatcher : CommandMatcher<QuitCommand>
    {
        public QuitCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^quit\s*$"),
                commandFactory)   
        {
        }
    }
}
