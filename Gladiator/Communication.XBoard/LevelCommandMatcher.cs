using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class LevelCommandMatcher : CommandMatcher<LevelCommand>
    {
        public LevelCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^level\s+(?<numMoves>\d+)\s+(?<controlBase>[\d:]+)\s+(?<incrementInSeconds>\d+)\s*$"),
                commandFactory)
        {
        }
    }
}
