namespace Dagaren.Gladiator.Protocol
{
    using System.Collections.Generic;

    interface ICommandFactory
    {
        TCommand Construct<TCommand>(IDictionary<string, string> parameters) where TCommand : ICommand;
    }
}
