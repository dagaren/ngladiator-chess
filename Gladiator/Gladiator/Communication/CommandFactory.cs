using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    class CommandFactory : ICommandFactory
    {
        private IDictionary<string, object> container;

        public CommandFactory(IDictionary<string, object> container)
        {
            Check.ArgumentNotNull(container, "container");

            this.container = container;
        }

        public TCommand Construct<TCommand>(IDictionary<string, string> parameters) where TCommand : ICommand
        {
            Type commandType = typeof(TCommand);

            ConstructorInfo[] constructors = commandType.GetConstructors();
            if(constructors.Length != 1)
            {
                throw new ArgumentException(
                    string.Format(
                        "The command of type <{0}> has <{1}> constructors. In order to construct a command, it must have just one constructor.", 
                        commandType.Name,
                        constructors.Length));
            }
            ConstructorInfo constructor = constructors.First();

            ParameterInfo[] constructorParameters = constructor.GetParameters();
            object[] parameterInstances = new object[constructorParameters.Length];
            foreach(ParameterInfo constructorParameter in constructorParameters)
            {
                if(this.container.ContainsKey(constructorParameter.Name))
                {
                    parameterInstances[constructorParameter.Position] = this.container[constructorParameter.Name];
                }
            }

            return (TCommand)constructor.Invoke(parameterInstances);
        }
    }
}
