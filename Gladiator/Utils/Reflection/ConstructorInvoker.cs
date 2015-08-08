using System;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public class ConstructorInvoker : IConstructorInvoker
    {
        public object Invoke(System.Reflection.ConstructorInfo constructor, IParameterFactory parameterFactory)
        {
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            object[] parameterInstances = new object[constructorParameters.Length];
            foreach (ParameterInfo constructorParameter in constructorParameters)
            {
                parameterInstances[constructorParameter.Position] = parameterFactory.Generate(constructorParameter);
            }

            return constructor.Invoke(parameterInstances);
        }
    }
}
