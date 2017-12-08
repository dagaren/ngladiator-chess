namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class UciNewGameCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*ucinewgame\s*$");

        public Type CommandType => typeof(UciNewGameCommand);
    }
}
