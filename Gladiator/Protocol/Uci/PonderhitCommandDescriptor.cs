namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class PonderhitCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*ponderhit\s*$");

        public Type CommandType => typeof(PonderhitCommand);
    }
}
