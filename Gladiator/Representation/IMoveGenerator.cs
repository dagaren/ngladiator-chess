using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public interface IMoveGenerator<in TPosition, out TBoard> where TPosition : IPosition<TBoard>
    {
        IList<Move> GetMoves(TPosition position);
    }
}
