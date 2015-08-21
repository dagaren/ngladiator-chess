using Gladiator.Representation;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public class BasicMoveSorter : IMoveSorter
    {
        public IEnumerable<Move> Sort(IEnumerable<Move> moves, IPosition<IBoard> position)
        {
            return moves.OrderBy(m => GetMoveValue(m, position));
        }

        private static int GetMoveValue(Move move, IPosition<IBoard> position)
        {
            int value = move.Destination.ManhattanDistanceToCenter();

            if (position.Board.GetPiece(move.Destination) != ColouredPiece.None)
            {
                value -= 10;
            }

            return value;
        }
    }
}
