using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    interface ICommandMatcher<out T> where T: ICommand
    {
        T Match(string commandString);
    }
}
