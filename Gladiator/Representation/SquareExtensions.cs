using System;

namespace Gladiator.Representation
{
    public static class SquareExtensions
    {
        public static File GetFile(this Square square)
        {
            if(square == Square.None)
            {
                return File.None;
            }

            return (File)((int)square & 7);
        }

        public static Rank GetRank(this Square square)
        {
            if(square == Square.None)
            {
                return Rank.None;
            }

            return (Rank)((int)square >> 3);
        }
        
        public static Square NextInFile(this Square square)
        {
            return FromRankAndFile(square.GetRank().Next(), square.GetFile());
        }

        public static Square PreviousInFile(this Square square)
        {
            return FromRankAndFile(square.GetRank().Previous(), square.GetFile());
        }

        public static Square NextInRank(this Square square)
        {
            return FromRankAndFile(square.GetRank(), square.GetFile().Next());
        }

        public static Square PreviousInRank(this Square square)
        {
            return FromRankAndFile(square.GetRank(), square.GetFile().Previous());
        }

        public static Square NextInDiagonal(this Square square)
        {
            return FromRankAndFile(square.GetRank().Next(), square.GetFile().Next());
        }

        public static Square PreviousInDiagonal(this Square square)
        {
            return FromRankAndFile(square.GetRank().Previous(), square.GetFile().Previous());
        }

        public static Square NextInAntiDiagonal(this Square square)
        {
            return FromRankAndFile(square.GetRank().Next(), square.GetFile().Previous());
        }

        public static Square PreviousInAntiDiagonal(this Square square)
        {
            return FromRankAndFile(square.GetRank().Previous(), square.GetFile().Next());
        }

        public static Square Next(this Square square)
        {
            if(square == Square.h8)
            {
                return Square.None;
            }

            return square + 1;
        }

        public static Square Previous(this Square square)
        {
            if (square == Square.a1)
            {
                return Square.None;
            }

            return square - 1;
        }

        public static int GetValue(this Square square)
        {
            return (int)square;
        }

        public static Square Mirror(this Square square)
        {
            return (Square)((square.GetValue() + 56) - ((square.GetValue() >> 3) << 4));
        }

        public static Square FromRankAndFile(Rank rank, File file)
        {
            if(file == File.None || rank == Rank.None)
            {
                return Square.None;
            }

            return (Square)(((int)rank << 3) + (int)file);
        }
    }
}
