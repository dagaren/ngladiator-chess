using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.XBoard
{
    public class LevelCommandMatcher : CommandMatcher<LevelCommand>
    {
        public const string NumMovesName = "numMoves";
        public const string MinutesName = "minutes";
        public const string SecondsName = "seconds";
        public const string IncrementInSecondsName = "incrementInSeconds";

        public LevelCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(string.Format(@"^level\s+(?<{0}>\d+)\s+(?<{1}>\d+)(:(?<{2}>\d+))?\s+(?<{3}>\d+)\s*$",
                        NumMovesName,
                        MinutesName,
                        SecondsName,
                        IncrementInSecondsName
                    )),
                commandFactory)
        {
        }
    }
}
