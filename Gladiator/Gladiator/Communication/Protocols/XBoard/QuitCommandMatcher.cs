using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
