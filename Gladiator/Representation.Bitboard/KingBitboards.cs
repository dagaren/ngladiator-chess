using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public static class KingBitboards
    {
        public readonly static ulong[] AttackBitboards = new ulong[64];

        static KingBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                ulong squareBitboard = square.GetBitboard();

                AttackBitboards[square.GetValue()] = (squareBitboard & ~(File.a.GetBitboard() | Rank._8.GetBitboard())) << 7 |
                                               (squareBitboard & ~Rank._8.GetBitboard()) << 8 |
                                               (squareBitboard & ~(File.h.GetBitboard() | Rank._8.GetBitboard())) << 9 |
                                               (squareBitboard & ~File.h.GetBitboard()) << 1 |
                                               (squareBitboard & ~File.a.GetBitboard()) >> 1 |
                                               (squareBitboard & ~(File.h.GetBitboard() | Rank._1.GetBitboard())) >> 7 |
                                               (squareBitboard & ~Rank._1.GetBitboard()) >> 8 |
                                               (squareBitboard & ~(File.a.GetBitboard() | Rank._1.GetBitboard())) >> 9;
            }
        }
    }
}
