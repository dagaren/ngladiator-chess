using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Notation
{
    static class ColouredPieceFormatExtensions
    {
        public static string Format(this ColouredPiece piece)
        {
            switch(piece)
            {
                case ColouredPiece.WhiteKing: return "K";
                case ColouredPiece.BlackKing: return "k";
                case ColouredPiece.WhiteQueen: return "Q";
                case ColouredPiece.BlackQueen: return "q";
                case ColouredPiece.WhiteBishop: return "B";
                case ColouredPiece.BlackBishop: return "b";
                case ColouredPiece.WhiteKnight: return "N";
                case ColouredPiece.BlackKnight: return "n";
                case ColouredPiece.WhiteRook: return "R";
                case ColouredPiece.BlackRook: return "r";
                case ColouredPiece.WhitePawn: return "P";
                case ColouredPiece.BlackPawn: return "p";
                default: return string.Empty;
            }
        }
    }
}
