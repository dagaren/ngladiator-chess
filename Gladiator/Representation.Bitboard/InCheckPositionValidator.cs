using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class InCheckPositionValidator<TPosition> : IPositionValidator<TPosition, BitboardBoard> where TPosition : IPosition<BitboardBoard>
    {
        public bool IsValid(TPosition position)
        {
            Colour turn = position.Turn;
            Square kingSquare = position.Board.pieceOccupation[Piece.King.GetColoured(turn.Opponent()).GetValue()]
                                    .FirstSquareScan();

            return !position.Board.IsAttacked(kingSquare, turn);
        }
    }
}
