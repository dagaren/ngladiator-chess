using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class MoveCommandMatcher : CommandMatcher<MoveCommand>
    {
        public MoveCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^(?<move>[a-h][1-8][a-h][1-8][qrbn]?)\s*$"),
                commandFactory)
        {
        }
    }
}
