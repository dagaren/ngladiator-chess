using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    class CommandFactory : ICommandFactory
    {
        public TCommand Construct<TCommand>(IDictionary<string, string> parameters) where TCommand : ICommand
        {
            return Activator.CreateInstance<TCommand>();
        }
    }
}
