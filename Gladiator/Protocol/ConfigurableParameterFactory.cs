namespace Dagaren.Gladiator.Protocol
{
    using System;
    using System.Reflection;
    using Dagaren.Gladiator.Utils;

    class ConfigurableParameterFactory : IParameterFactory
    {
        private Func<ParameterInfo, object> fillerFunction;

        public ConfigurableParameterFactory(Func<ParameterInfo, object> fillerFunction)
        {
            this.fillerFunction = fillerFunction ?? throw new ArgumentNullException(nameof(fillerFunction));
        }

        public object Generate(ParameterInfo parameter)
        {
            return this.fillerFunction(parameter);
        }
    }
}
