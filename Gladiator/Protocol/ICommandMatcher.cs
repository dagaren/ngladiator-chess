namespace Dagaren.Gladiator.Protocol
{
    interface ICommandMatcher
    {
        ICommand Match(string commandString);
    }
}
