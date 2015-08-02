using Gladiator.Utils;
using Gladiator.Representation;
using System;

namespace Gladiator.Representation.Bitboard
{
    static class RotationSquareExtensions
    {
        private static readonly Square[] SquaresRotated90DegreesLeft = new Square[64];

        private static readonly Square[] SquaresRotated90DegreesRight = new Square[64];

        private static readonly Square[] SquaresDiagonalRotated45DegreesLeft = new Square[64];

        private static readonly Square[] SquaresDiagonalRotated45DegreesRight = new Square[64];

        private static readonly Square[] SquaresAntidiagonalRotated45DegreesLeft = new Square[64];

        private static readonly Square[] SquaresAntidiagonalRotated45DegreesRight = new Square[64];

        private static readonly ulong[] DiagonalRotatedMasks = new ulong[64];

        private static readonly ulong[] AntidiagonalRotatedMasks = new ulong[64];

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

                SquaresDiagonalRotated45DegreesLeft[square.GetValue()] = CalculateSquareDiagonalRotated45DegreesLeft(square);
                SquaresDiagonalRotated45DegreesRight[square.GetValue()] = CalculateSquareDiagonalRotated45DegreesRight(square);

                SquaresAntidiagonalRotated45DegreesLeft[square.GetValue()] = CalculateSquareAntidiagonalRotated45DegreesLeft(square);
                SquaresAntidiagonalRotated45DegreesRight[square.GetValue()] = CalculateSquareAntidiagonalRotated45DegreesRight(square);

                DiagonalRotatedMasks[square.GetValue()] = CalculateDiagonalMask(square);
                AntidiagonalRotatedMasks[square.GetValue()] = CalculateAntidiagonalMask(square);
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

        public static Square DiagonalRotated45DegreesRight(this Square square)
        {
            if (square == Square.None)
            {
                return Square.None;
            }

            return SquaresDiagonalRotated45DegreesRight[square.GetValue()];
        }


        public static Square DiagonalRotated45DegreesLeft(this Square square)
        {
            if (square == Square.None)
            {
                return Square.None;
            }

            return SquaresDiagonalRotated45DegreesLeft[square.GetValue()];
        }

        public static Square AntidiagonalRotated45DegreesLeft(this Square square)
        {
            if (square == Square.None)
            {
                return Square.None;
            }

            return SquaresAntidiagonalRotated45DegreesLeft[square.GetValue()];
        }

        public static Square AntidiagonalRotated45DegreesRight(this Square square)
        {
            if (square == Square.None)
            {
                return Square.None;
            }

            return SquaresAntidiagonalRotated45DegreesRight[square.GetValue()];
        }

        public static ulong DiagonalRotatedMask(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return DiagonalRotatedMasks[square.GetValue()];
        }

        public static ulong AntidiagonalRotatedMask(this Square square)
        {
            if (square == Square.None)
            {
                return BitboardExtensions.Empty;
            }

            return AntidiagonalRotatedMasks[square.GetValue()];
        }

        private static Square CalculateSquareDiagonalRotated45DegreesRight(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();

            if(rank.GetValue() - file.GetValue() >= 0)
            {
                return (Square)(8 * (rank.GetValue() - file.GetValue()) + file.GetValue());
            }
            else
            {
                return (Square)(8 * (rank.GetValue() - file.GetValue() + 8) + file.GetValue());
            }
        }

        private static Square CalculateSquareDiagonalRotated45DegreesLeft(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();

            if (rank.GetValue() + file.GetValue() > 7)
            {
                return (Square)(8 * (rank.GetValue() + file.GetValue() - 8) + file.GetValue());
            }
            else
            {
                return (Square)(8 * (rank.GetValue() + file.GetValue()) + file.GetValue());
            }
        }

        private static Square CalculateSquareAntidiagonalRotated45DegreesRight(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();

            return (Square)(((rank.GetValue() + 7 - file.GetValue()) % 8) * 8 + file.GetValue());
        }

        private static Square CalculateSquareAntidiagonalRotated45DegreesLeft(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();

            return (Square)(((1 + rank.GetValue() + file.GetValue()) % 8) * 8 + file.GetValue());
        }

        private static ulong CalculateDiagonalMask(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();
           
            if(file.GetValue() <= (7 - rank.GetValue()))
            {
                return (Rank._1.GetBitboard() >> rank.GetValue()) << 8 * rank.GetValue();
            }
            else
            {
                return (Rank._1.GetBitboard() ^ (Rank._1.GetBitboard() >> rank.GetValue())) << 8 * rank.GetValue();
            }
        }

        private static ulong CalculateAntidiagonalMask(Square square)
        {
            Rank rank = square.GetRank();
            File file = square.GetFile();
            ulong firstRankBitboard = Rank._1.GetBitboard();
           
            if(rank.GetValue() > file.GetValue())
            {
                return ((firstRankBitboard ^ (firstRankBitboard << rank.GetValue())) & firstRankBitboard) << 8 * rank.GetValue();
            }
            else
            {
                return ((firstRankBitboard << rank.GetValue()) & firstRankBitboard) << 8 * rank.GetValue();
            }
        }
    }
}
