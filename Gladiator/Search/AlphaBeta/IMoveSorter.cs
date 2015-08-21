using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public interface IMoveSorter
    {
        IEnumerable<Move> Sort(IEnumerable<Move> moves, IPosition<IBoard> position);
    }
}
