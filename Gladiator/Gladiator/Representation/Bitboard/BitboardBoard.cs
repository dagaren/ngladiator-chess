using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Representation.Bitboard
{
    class BitboardBoard : IBoard
    {
        internal ColouredPiece[] piecesInSquare;

        internal ulong occupation;

        internal readonly ulong[] pieceOccupation;

        internal readonly ulong[] colourOccupation;

        public BitboardBoard()
        {
            this.piecesInSquare = Enumerable.Repeat(ColouredPiece.None, 64).ToArray();
            this.occupation = BitboardExtensions.Empty;
            this.pieceOccupation = Enumerable.Repeat(BitboardExtensions.Empty, 12).ToArray();
            this.colourOccupation = Enumerable.Repeat(BitboardExtensions.Empty, 2).ToArray();
        }

        public void PutPiece(ColouredPiece piece, Square square)
        {
            if(this.piecesInSquare[square.GetValue()] != ColouredPiece.None)
            {
                throw new ArgumentException(string.Format("There is already a piece {0} in the square {1}", this.piecesInSquare[square.GetValue()], square));
            }

            this.piecesInSquare[square.GetValue()] = piece;

            this.occupation = this.occupation.Or(square.GetBitboard());
            this.pieceOccupation[piece.GetValue()] = this.pieceOccupation[piece.GetValue()].Or(square.GetBitboard());
            this.colourOccupation[piece.GetColour().GetValue()] = this.colourOccupation[piece.GetColour().GetValue()].Or(square.GetBitboard());
        }

        public void RemovePiece(Square square)
        {
            ColouredPiece piece = this.piecesInSquare[square.GetValue()];
            if(piece == ColouredPiece.None)
            {
                throw new ArgumentException(string.Format("There is not any piece in the square {1}", square));
            }

            this.piecesInSquare[square.GetValue()] = ColouredPiece.None;

            this.occupation = this.occupation.Xor(square.GetBitboard());
            this.pieceOccupation[piece.GetValue()] = this.pieceOccupation[piece.GetValue()].Xor(square.GetBitboard());
            this.colourOccupation[piece.GetColour().GetValue()] = this.colourOccupation[piece.GetColour().GetValue()].Xor(square.GetBitboard());
        }

        public ColouredPiece GetPiece(Square square)
        {
            return this.piecesInSquare[square.GetValue()];
        }
    }
}
