using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class EasyCommandMatcher : CommandMatcher<EasyCommand>
    {
        public EasyCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^easy\s*$"),
                commandFactory)
        {
        }
    }
}
