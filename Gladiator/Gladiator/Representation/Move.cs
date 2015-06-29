using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    class Move
    {
        public Square Source { get; set; }
        public Square Destination { get; set; }

        public Piece Promotion { get; set; }
    }
}
