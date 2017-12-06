namespace Dagaren.Gladiator.Protocol
{
    using Dagaren.Gladiator.Utils;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    class CommandFactory : ICommandFactory
    {
        private IDictionary<string, object> container;

        public CommandFactory(
            IDictionary<string, object> container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public TCommand Construct<TCommand>(IDictionary<string, string> parameters) where TCommand : ICommand
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            ConstructorInfo constructor = typeof(TCommand).GetConstructor();

            IParameterFactory parameterFactory = new ConfigurableParameterFactory(parameter => {
                if (parameters.ContainsKey(parameter.Name))
                {
                    var attribute = parameter.GetCustomAttribute<CommmandParameterAttribute>(false);
                    if (attribute != null)
                    {
                        Type parserType = attribute.ParserType;
                        dynamic parser = Activator.CreateInstance(parserType);
                        return parser.Parse(parameters[parameter.Name]);
                    }

                    return Convert.ChangeType(parameters[parameter.Name], parameter.ParameterType, CultureInfo.InvariantCulture);
                }

                if (this.container.ContainsKey(parameter.Name))
                {
                    return this.container[parameter.Name];
                }

                throw new ArgumentException(string.Format("Value for parameter '{0}' not found", parameter.Name));
            });

            return (TCommand)constructor.Invoke(parameterFactory);
        }
    }
}
