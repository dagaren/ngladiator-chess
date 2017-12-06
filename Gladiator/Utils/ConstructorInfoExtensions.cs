namespace Dagaren.Gladiator.Utils
{
    using System.Reflection;

    static class ConstructorInfoExtensions
    {
        public static object Invoke(this ConstructorInfo constructor, IParameterFactory parameterFactory)
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
