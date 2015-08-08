using System;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public class ConfigurableParameterFactory : IParameterFactory
    {
        private Func<ParameterInfo, object> fillerFunction;

        public ConfigurableParameterFactory(Func<ParameterInfo, object> function)
        {
            this.fillerFunction = function;
        }

        public object Generate(ParameterInfo parameter)
        {
            return this.fillerFunction(parameter);
        }
    }
}
