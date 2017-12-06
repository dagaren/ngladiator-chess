namespace Dagaren.Gladiator.Protocol
{
    internal interface IParser<out T>
    {
        T Parse(string input);
    }
}