using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public static class KingBitboards
    {
        public readonly static ulong[] AttackBitboards = new ulong[64];

        public readonly static ulong[,] CastlingSquares = new ulong[2, 2];

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

                CastlingSquares[CastlingType.Short.Value(), Colour.White.Value()] = BitboardExtensions.FromSquares(Square.f1, Square.g1);
                CastlingSquares[CastlingType.Short.Value(), Colour.Black.Value()] = BitboardExtensions.FromSquares(Square.f8, Square.g8);
                CastlingSquares[CastlingType.Long.Value(), Colour.White.Value()] = BitboardExtensions.FromSquares(Square.b1, Square.c1, Square.d1);
                CastlingSquares[CastlingType.Long.Value(), Colour.Black.Value()] = BitboardExtensions.FromSquares(Square.b8, Square.c8, Square.d8);
            }
        }
    }
}
