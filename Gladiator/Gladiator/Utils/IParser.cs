using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    interface IParser<out T>
    {
        T Parse(string input);
    }
}
