using Gladiator.Representation;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public class BasicMoveSorter : IMoveSorter
    {
        public IEnumerable<Move> Sort(IEnumerable<Move> moves, SearchStatus searchStatus)
        {
            return moves.OrderBy(m => GetMoveValue(m, searchStatus));
        }

        private static int GetMoveValue(Move move, SearchStatus searchStatus)
        {
            int value = move.Destination.ManhattanDistanceToCenter();

            if (searchStatus.Position.Board.GetPiece(move.Destination) != ColouredPiece.None)
            {
                value -= 10;
            }
            
            if(move == searchStatus.SuggestedMove)
            {
                value -= 100;
            }

            return value;
        }
    }
}
