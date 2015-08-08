using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Utils;
using Gladiator.Utils.Reflection;
using System.Globalization;

namespace Gladiator.Communication
{
    public class CommandFactory : ICommandFactory
    {
        private IDictionary<string, object> container;

        private IConstructorRetriever constructorRetriever;

        private IConstructorInvoker constructorInvoker;

        public CommandFactory(
            IDictionary<string, object> container,
            IConstructorRetriever constructorRetriever,
            IConstructorInvoker constructorInvoker)
        {
            Check.ArgumentNotNull(container, "container");
            Check.ArgumentNotNull(constructorRetriever, "constructorRetriever");
            Check.ArgumentNotNull(constructorInvoker, "constructorInvoker");

            this.container = container;
            this.constructorRetriever = constructorRetriever;
            this.constructorInvoker = constructorInvoker;
        }

        public TCommand Construct<TCommand>(IDictionary<string, string> parameters) where TCommand : ICommand
        {
            Check.ArgumentNotNull(parameters, "parameters");

            ConstructorInfo constructor = this.constructorRetriever.GetConstructor(typeof(TCommand));

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

            return (TCommand)this.constructorInvoker.Invoke(constructor, parameterFactory);
        }
    }
}
