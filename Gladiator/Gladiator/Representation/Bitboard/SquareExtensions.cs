using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    static class SquareExtensions
    {
        public readonly static ulong[] Squares = new ulong[64];

        static SquareExtensions()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                Squares[square.GetValue()] = 1UL.ShiftRight(square.GetValue());
            }
        }

        public static ulong GetBitboard(this Square square)
        {
            return Squares[square.GetValue()];
        }

        public static ulong GetBitboard(params Square[] squares)
        {
            ulong bitboard = 0UL;

            foreach(Square square in squares)
            {
                bitboard = bitboard.Or(square.GetBitboard());
            }

            return bitboard;
        }
    }
}
