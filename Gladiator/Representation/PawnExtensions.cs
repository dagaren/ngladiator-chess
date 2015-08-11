using Gladiator.Utils;
using System;

namespace Gladiator.Representation
{
    public static class PawnExtensions
    {
        public static readonly Square[] EnPassantCapturedPawnSquare = new Square[64];

        public static readonly Rank[] EnPassantSourceRanks = new Rank[2];

        public static readonly Rank[] EnPassantDestinationRanks = new Rank[2];

        static PawnExtensions()
        {
            EnPassantSourceRanks[Colour.White.Value()] = Rank._2;
            EnPassantSourceRanks[Colour.Black.Value()] = Rank._7;
            EnPassantDestinationRanks[Colour.White.Value()] = Rank._4;
            EnPassantDestinationRanks[Colour.Black.Value()] = Rank._5;

            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                Square capturedPawnSquare = Square.None;

                if(square.GetRank() == Rank._3)
                {
                    capturedPawnSquare = square.NextInFile();
                }
                else if(square.GetRank() == Rank._6)
                {
                    capturedPawnSquare = square.PreviousInFile();
                }

                EnPassantCapturedPawnSquare[square.GetValue()] = capturedPawnSquare;
            }
        }
    }
}
