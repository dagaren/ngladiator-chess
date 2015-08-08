using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public static class MoveExtensions
    {
        public static string Format(this Move move)
        {
            return string.Format("{0}{1}", move.Source, move.Destination);
        }
    }
}
