namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class IsReadyCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*isready\s*$");

        public Type CommandType => typeof(IsReadyCommand);
    }
}
