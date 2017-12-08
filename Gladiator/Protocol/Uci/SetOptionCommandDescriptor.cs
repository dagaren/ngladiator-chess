namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class SetOptionCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex("");

        public Type CommandType => typeof(SetOptionCommand);
    }
}
