using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Bitboard
{
    static class KingBitboards
    {
        public static ulong[] AttackBitboards = new ulong[64];

        static KingBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                ulong squareBitboard = square.GetBitboard();

                AttackBitboards[(int)square] = (squareBitboard & ~(File.a.GetBitboard() | Rank._8.GetBitboard())) << 7 |
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
