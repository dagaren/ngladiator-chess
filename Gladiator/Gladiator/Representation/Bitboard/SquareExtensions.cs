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
            if(square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

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

        public static ulong RightBitboard(this Square square)
        {
            if(square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.Right[square.GetValue()];
        }

        public static ulong LeftBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.Left[square.GetValue()];
        }

        public static ulong TopBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.Top[square.GetValue()];
        }

        public static ulong BottomBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.Bottom[square.GetValue()];
        }

        public static ulong TopRightBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.TopRight[square.GetValue()];
        }

        public static ulong TopLeftBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.TopLeft[square.GetValue()];
        }

        public static ulong BottomRightBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.BottomRight[square.GetValue()];
        }

        public static ulong BottomLeftBitboard(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DirectionBitboards.BottomLeft[square.GetValue()];
        }
    }
}
