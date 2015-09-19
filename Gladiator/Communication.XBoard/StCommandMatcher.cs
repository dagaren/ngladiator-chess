using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Communication.XBoard
{
    public class StCommandMatcher : CommandMatcher<StCommand>
    {
        public const string TimeName = "time";

        public StCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(string.Format(@"^st\s+(?<{0}>\d+)\s*$", TimeName)),
                commandFactory)
        {
        }
    }
}
