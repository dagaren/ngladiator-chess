using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    public interface IParser<out T>
    {
        T Parse(string input);
    }
}
