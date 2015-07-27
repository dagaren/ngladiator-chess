using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    class KnightBitboards
    {
        public readonly static ulong[] AttackBitboards = new ulong[64];

        static KnightBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                ulong squareBitboard = square.GetBitboard();

                AttackBitboards[square.GetValue()] = (squareBitboard & ~(Rank._8.GetBitboard() | File.a.GetBitboard() | File.b.GetBitboard())) << 6  |
                                                     (squareBitboard & ~(Rank._8.GetBitboard() | File.h.GetBitboard() | File.g.GetBitboard())) << 10 |
                                                     (squareBitboard & ~(Rank._8.GetBitboard() | Rank._7.GetBitboard() | File.a.GetBitboard())) << 15 |
                                                     (squareBitboard & ~(Rank._8.GetBitboard() | Rank._7.GetBitboard() | File.h.GetBitboard())) << 17 |
                                                     (squareBitboard & ~(Rank._1.GetBitboard() | File.a.GetBitboard() | File.b.GetBitboard())) >> 10 |
                                                     (squareBitboard & ~(Rank._1.GetBitboard() | File.h.GetBitboard() | File.g.GetBitboard())) >> 6  |
                                                     (squareBitboard & ~(Rank._1.GetBitboard() | Rank._1.GetBitboard() | File.a.GetBitboard())) >> 17 |
                                                     (squareBitboard & ~(Rank._1.GetBitboard() | Rank._1.GetBitboard() | File.h.GetBitboard())) >> 15;
            }
        }
    }
}
