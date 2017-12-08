namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class StopCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*stop\s*$");

        public Type CommandType => typeof(StopCommand);
    }
}
