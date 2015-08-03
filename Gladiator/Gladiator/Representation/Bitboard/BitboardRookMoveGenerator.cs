using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    class BitboardRookMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.Rook;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            ulong attackedBitboard = SlidingBitboards.GetFileAttack(source, position.Board.occupation);
            attackedBitboard |= SlidingBitboards.GetRankAttack(source, position.Board.occupation);

            return attackedBitboard;
        }
    }
}
