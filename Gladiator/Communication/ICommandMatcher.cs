using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    public interface ICommandMatcher<out TCommand> where TCommand : ICommand
    {
        TCommand Match(string commandString);
    }
}
