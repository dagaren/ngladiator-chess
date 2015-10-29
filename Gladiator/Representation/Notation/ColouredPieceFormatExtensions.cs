using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Notation
{
    public static class ColouredPieceFormatExtensions
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

        public static ColouredPiece Parse(string input)
        {
            switch(input)
            {
                case "K": return ColouredPiece.WhiteKing;
                case "k": return ColouredPiece.BlackKing;
                case "Q": return ColouredPiece.WhiteQueen;
                case "q": return ColouredPiece.BlackQueen;
                case "B": return ColouredPiece.WhiteBishop;
                case "b": return ColouredPiece.BlackBishop;
                case "N": return ColouredPiece.WhiteKnight;
                case "n": return ColouredPiece.BlackKnight;
                case "R": return ColouredPiece.WhiteRook;
                case "r": return ColouredPiece.BlackRook;
                case "P": return ColouredPiece.WhitePawn;
                case "p": return ColouredPiece.BlackPawn;
                default: throw new ArgumentException(string.Format("Invalid coloured piece text: {0}", input));
            }
        }
    }
}
