using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Notation
{
    interface IMoveParser
    {
        Move Parse(string moveString);
    }
}
