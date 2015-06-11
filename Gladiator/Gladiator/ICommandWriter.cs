using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    internal interface ICommandWriter
    {
        void Write(string command);
    }
}
