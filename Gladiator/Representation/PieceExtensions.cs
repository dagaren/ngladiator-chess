using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public static class PieceExtensions
    {
        private static Piece[] pieces = new Piece[12];

        private static Colour[] colours = new Colour[12];

        private static ColouredPiece[,] colouredPieces = new ColouredPiece[2,6];

        static PieceExtensions()
        {
            SetPieceEquivalent(ColouredPiece.WhitePawn, Piece.Pawn);
            SetPieceEquivalent(ColouredPiece.BlackPawn, Piece.Pawn);
            SetPieceEquivalent(ColouredPiece.WhiteRook, Piece.Rook);
            SetPieceEquivalent(ColouredPiece.BlackRook, Piece.Rook);
            SetPieceEquivalent(ColouredPiece.WhiteKnight, Piece.Knight);
            SetPieceEquivalent(ColouredPiece.BlackKnight, Piece.Knight);
            SetPieceEquivalent(ColouredPiece.WhiteBishop, Piece.Bishop);
            SetPieceEquivalent(ColouredPiece.BlackBishop, Piece.Bishop);
            SetPieceEquivalent(ColouredPiece.WhiteQueen, Piece.Queen);
            SetPieceEquivalent(ColouredPiece.BlackQueen, Piece.Queen);
            SetPieceEquivalent(ColouredPiece.WhiteKing, Piece.King);
            SetPieceEquivalent(ColouredPiece.BlackKing, Piece.King);

            SetColourEquivalent(ColouredPiece.WhitePawn, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackPawn, Colour.Black);
            SetColourEquivalent(ColouredPiece.WhiteRook, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackRook, Colour.Black);
            SetColourEquivalent(ColouredPiece.WhiteKnight, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackKnight, Colour.Black);
            SetColourEquivalent(ColouredPiece.WhiteBishop, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackBishop, Colour.Black);
            SetColourEquivalent(ColouredPiece.WhiteQueen, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackQueen, Colour.Black);
            SetColourEquivalent(ColouredPiece.WhiteKing, Colour.White);
            SetColourEquivalent(ColouredPiece.BlackKing, Colour.Black);

            SetColouredPieceEquivalent(Piece.Pawn, Colour.White, ColouredPiece.WhitePawn);
            SetColouredPieceEquivalent(Piece.Rook, Colour.White, ColouredPiece.WhiteRook);
            SetColouredPieceEquivalent(Piece.Knight, Colour.White, ColouredPiece.WhiteKnight);
            SetColouredPieceEquivalent(Piece.Bishop, Colour.White, ColouredPiece.WhiteBishop);
            SetColouredPieceEquivalent(Piece.Queen, Colour.White, ColouredPiece.WhiteQueen);
            SetColouredPieceEquivalent(Piece.King, Colour.White, ColouredPiece.WhiteKing);
            SetColouredPieceEquivalent(Piece.Pawn, Colour.Black, ColouredPiece.BlackPawn);
            SetColouredPieceEquivalent(Piece.Rook, Colour.Black, ColouredPiece.BlackRook);
            SetColouredPieceEquivalent(Piece.Knight, Colour.Black, ColouredPiece.BlackKnight);
            SetColouredPieceEquivalent(Piece.Bishop, Colour.Black, ColouredPiece.BlackBishop);
            SetColouredPieceEquivalent(Piece.Queen, Colour.Black, ColouredPiece.BlackQueen);
            SetColouredPieceEquivalent(Piece.King, Colour.Black, ColouredPiece.BlackKing);
        }

        public static Piece GetPiece(this ColouredPiece colouredPiece)
        {
            if(colouredPiece == ColouredPiece.None)
            {
                return Piece.None;
            }

            return pieces[(int)colouredPiece];
        }

        public static Colour GetColour(this ColouredPiece colourPiece)
        {
            if(colourPiece == ColouredPiece.None)
            {
                return Colour.None;
            }

            return colours[(int)colourPiece];
        }

        public static int GetValue(this ColouredPiece colouredPiece)
        {
            return (int)colouredPiece;
        }

        public static ColouredPiece GetColoured(this Piece piece, Colour colour)
        {
           return colouredPieces[colour.GetValue(), piece.GetValue()];
        }

        public static int GetValue(this Piece piece)
        {
            return (int)piece;
        }

        private static void SetPieceEquivalent(ColouredPiece colouredPiece, Piece piece)
        {
            pieces[(int)colouredPiece] = piece;
        }

        private static void SetColourEquivalent(ColouredPiece colouredPiece, Colour colour)
        {
            colours[(int)colouredPiece] = colour;
        }

        private static void SetColouredPieceEquivalent(Piece piece, Colour colour, ColouredPiece colouredPiece)
        {
            colouredPieces[colour.GetValue(), piece.GetValue()] = colouredPiece;
        }
    }
}
