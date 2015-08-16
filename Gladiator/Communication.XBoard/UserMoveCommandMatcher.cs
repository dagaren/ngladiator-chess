using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class UserMoveCommandMatcher : CommandMatcher<UserMoveCommand>
    {
        public UserMoveCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^(usermove )?(?<move>[a-h][1-8][a-h][1-8][qrbn]?)\s*$"),
                commandFactory)
        {
        }
    }
}
