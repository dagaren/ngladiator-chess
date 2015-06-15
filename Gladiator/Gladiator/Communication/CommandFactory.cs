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
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public T Construct<T> (IDictionary<string, string> parameters) where T : ICommand
        {
            Type commandType = typeof(T);

            ConstructorInfo[] constructors = commandType.GetConstructors();
            if(constructors.Length != 1)
            {
                throw new ArgumentException("A command must have one single constructor");
            }

            ConstructorInfo constructor = constructors.First();

            T instance = Activator.CreateInstance<T>();

            return instance;
        }
    }
}
