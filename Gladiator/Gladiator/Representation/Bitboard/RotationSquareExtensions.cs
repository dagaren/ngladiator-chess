using Gladiator.Utils;
using Gladiator.Representation;
using System;

namespace Gladiator.Representation.Bitboard
{
    static class RotationSquareExtensions
    {
        private static readonly Square[] SquaresRotated90DegreesLeft = new Square[64];

        private static readonly Square[] SquaresRotated90DegreesRight = new Square[64];

        static RotationSquareExtensions()
        {
            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                Rank rank = square.GetRank();
                File file = square.GetFile();
  
                SquaresRotated90DegreesLeft[square.GetValue()] = (Square)(8 * file.GetValue()) + (7 - rank.GetValue());
                SquaresRotated90DegreesRight[square.GetValue()] = (Square)(8 * (7 - file.GetValue()) + rank.GetValue());
            }
        }

        public static Square Rotated90DegreesRight(this Square square)
        {
            if(square == Square.None)
            {
                return Square.None;
            }

            return SquaresRotated90DegreesRight[square.GetValue()];
        }

        public static Square Rotated90DegreesLeft(this Square square)
        {
            if (square == Square.None)
            {
                return Square.None;
            }

            return SquaresRotated90DegreesLeft[square.GetValue()];
        }

    }
}
