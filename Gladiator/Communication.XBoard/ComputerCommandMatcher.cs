using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class ComputerCommandMatcher: CommandMatcher<ComputerCommand>
    {
        public ComputerCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^computer\s*$"),
                commandFactory)
        {
        }
    }
}
