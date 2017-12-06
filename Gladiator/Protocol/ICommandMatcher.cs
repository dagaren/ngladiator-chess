namespace Dagaren.Gladiator.Protocol
{
    interface ICommandMatcher<out TCommand> where TCommand : ICommand
    {
        TCommand Match(string commandString);
    }
}
