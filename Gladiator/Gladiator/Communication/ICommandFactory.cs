using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    interface ICommandFactory
    {
        T Construct<T> (IDictionary<string, string> parameters) where T : ICommand;
    }
}
