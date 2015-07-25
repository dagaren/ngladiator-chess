using Gladiator.Communication;
using Gladiator.Utils.Reflection;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Communication.Builders
{
    class CommandFactoryBuilder
    {
        private Dictionary<string, object> container = new Dictionary<string, object>();

        public CommandFactoryBuilder WithContainerParameter(string parameterName, object parameterValue)
        {
            this.container[parameterName] = parameterValue;

            return this;
        }

        public CommandFactory Build()
        {
            IConstructorRetriever constructorRetriever = new SingleConstructorRetriever();
            IConstructorInvoker constructorInvoker = new ConstructorInvoker();

            return new CommandFactory(this.container, constructorRetriever, constructorInvoker);
        }
    }
}
