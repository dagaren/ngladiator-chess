using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardCommandMatcher : CommandMatcher<XBoardCommand>
    {
        public XBoardCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^\s*xboard\s*$"),
                commandFactory
            )
        {
        }
    }
}
