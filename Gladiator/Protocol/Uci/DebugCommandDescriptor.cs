namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class DebugCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*debug\s+(?<enabled>on|off)\s*$");

        public Type CommandType => typeof(DebugCommand);
    }
}
