using System;

namespace Gladiator.Representation.Notation
{
    public static class PieceFormatExtensions
    {
        public static string FormatPromotion(this Piece piece)
        {
            switch (piece)
            {
                case Piece.Queen: return "q";
                case Piece.Bishop: return "b";
                case Piece.Knight: return "n";
                case Piece.Rook: return "n";
                default: return string.Empty;
            }
        }

    }
}
