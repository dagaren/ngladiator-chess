using System;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public interface IConstructorRetriever
    {
        ConstructorInfo GetConstructor(Type type);
    }
}
