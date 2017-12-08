namespace Dagaren.Gladiator.Protocol
{
    using System;
    using System.Text.RegularExpressions;

    interface ICommandDescriptor
    {
        Regex CommandRegex { get; }

        Type CommandType { get; }
    }
}
