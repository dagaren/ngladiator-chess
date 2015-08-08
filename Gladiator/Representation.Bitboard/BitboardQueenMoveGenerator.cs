using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardQueenMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.Queen;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            ulong attackedBitboard = SlidingBitboards.GetDiagonalAttack(source, position.Board.occupation);
            attackedBitboard |= SlidingBitboards.GetAntidiagonalAttack(source, position.Board.occupation);
            attackedBitboard |= SlidingBitboards.GetFileAttack(source, position.Board.occupation);
            attackedBitboard |= SlidingBitboards.GetRankAttack(source, position.Board.occupation);

            return attackedBitboard;
        }
    }
}
