using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    class BitboardKingMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.King;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            return KingBitboards.AttackBitboards[source.GetValue()];
        }
    }
}