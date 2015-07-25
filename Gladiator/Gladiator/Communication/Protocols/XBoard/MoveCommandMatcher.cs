using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard
{
    class MoveCommandMatcher : CommandMatcher<MoveCommand>
    {
        public MoveCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^(?<move>[a-h][1-8][a-h][1-8][qrbn]?)\s*$"),
                commandFactory)
        {
        }
    }
}
