using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    interface IFormatter<in T>
    {
        string Format(T input);
    }
}
