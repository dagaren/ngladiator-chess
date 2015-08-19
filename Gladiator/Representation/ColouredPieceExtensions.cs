using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public static class ColouredPieceExtensions
    {
        private static readonly IEnumerable<ColouredPiece> allPieces = new ColouredPiece[]{
            ColouredPiece.WhitePawn,
            ColouredPiece.BlackPawn,
            ColouredPiece.WhiteRook,
            ColouredPiece.BlackRook,
            ColouredPiece.WhiteKnight,
            ColouredPiece.BlackKnight,
            ColouredPiece.WhiteBishop,
            ColouredPiece.BlackBishop,
            ColouredPiece.WhiteQueen,
            ColouredPiece.BlackQueen,
            ColouredPiece.WhiteKing,
            ColouredPiece.BlackKing
        };

        public static IEnumerable<ColouredPiece> AllPieces()
        {
            return allPieces;
        }
    }
}
