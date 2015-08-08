using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardBishopMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.Bishop;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            ulong attackedBitboard = SlidingBitboards.GetDiagonalAttack(source, position.Board.occupation);
            attackedBitboard |= SlidingBitboards.GetAntidiagonalAttack(source, position.Board.occupation);

            return attackedBitboard;
        }
    }
}
