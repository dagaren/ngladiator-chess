namespace Dagaren.Gladiator.Utils
{
    using System.Reflection;

    public interface IParameterFactory
    {
        object Generate(ParameterInfo parameter);
    }
}