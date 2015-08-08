using System;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public interface IConstructorInvoker
    {
        object Invoke(ConstructorInfo constructor, IParameterFactory parameterFactory);
    }
}
