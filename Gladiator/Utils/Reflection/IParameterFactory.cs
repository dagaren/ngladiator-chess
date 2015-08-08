using System;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public interface IParameterFactory
    {
        object Generate(ParameterInfo parameter);
    }
}
