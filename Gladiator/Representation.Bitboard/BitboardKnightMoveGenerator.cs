using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardKnightMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.Knight;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            return KnightBitboards.AttackBitboards[source.GetValue()];
        }
    }
}
