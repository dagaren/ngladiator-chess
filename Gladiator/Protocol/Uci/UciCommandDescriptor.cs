namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class UciCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*uci\s*$");

        public Type CommandType => typeof(UciCommand);
    }
}
