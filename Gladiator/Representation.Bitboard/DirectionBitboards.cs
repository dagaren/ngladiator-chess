using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public class DirectionBitboards
    {
        public readonly static ulong[] Right = new ulong[64];

        public readonly static ulong[] Left = new ulong[64];

        public readonly static ulong[] Top = new ulong[64];

        public readonly static ulong[] Bottom = new ulong[64];

        public readonly static ulong[] BottomRight = new ulong[64];

        public readonly static ulong[] BottomLeft = new ulong[64];

        public readonly static ulong[] TopRight = new ulong[64];

        public readonly static ulong[] TopLeft = new ulong[64];

        static DirectionBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                InitRight(square);
                InitLeft(square);
                InitTop(square);
                InitBottom(square);
                InitTopLeft(square);
                InitTopRight(square);
                InitBottomLeft(square);
                InitBottomRight(square);
            }
        }

        private static void InitRight(Square square)
        {
            Square originalSquare = square;

            Right[square.GetValue()] = 0;
            
            while((square = square.NextInRank()) != Square.None)
            {
                Right[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitLeft(Square square)
        {
            Square originalSquare = square;

            Left[square.GetValue()] = 0;

            while ((square = square.PreviousInRank()) != Square.None)
            {
                Left[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitTop(Square square)
        {
            Square originalSquare = square;

            Top[square.GetValue()] = 0;

            while ((square = square.NextInFile()) != Square.None)
            {
                Top[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitBottom(Square square)
        {
            Square originalSquare = square;

            Bottom[square.GetValue()] = 0;

            while ((square = square.PreviousInFile()) != Square.None)
            {
                Bottom[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitTopRight(Square square)
        {
            Square originalSquare = square;

            TopRight[square.GetValue()] = 0;

            while ((square = square.NextInDiagonal()) != Square.None)
            {
                TopRight[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitTopLeft(Square square)
        {
            Square originalSquare = square;

            TopLeft[square.GetValue()] = 0;

            while ((square = square.NextInAntiDiagonal()) != Square.None)
            {
                TopLeft[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitBottomRight(Square square)
        {
            Square originalSquare = square;

            BottomRight[square.GetValue()] = 0;

            while ((square = square.PreviousInAntiDiagonal()) != Square.None)
            {
                BottomRight[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

        private static void InitBottomLeft(Square square)
        {
            Square originalSquare = square;

            BottomLeft[square.GetValue()] = 0;

            while ((square = square.PreviousInDiagonal()) != Square.None)
            {
                BottomLeft[originalSquare.GetValue()] |= square.GetBitboard();
            }
        }

    }
}
