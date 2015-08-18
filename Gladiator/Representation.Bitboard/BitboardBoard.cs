using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardBoard : IBoard
    {
        public ColouredPiece[] piecesInSquare;

        public ulong occupation;

        public readonly ulong[] pieceOccupation;

        public readonly ulong[] colourOccupation;

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
            this.colourOccupation[piece.GetColour().Value()] = this.colourOccupation[piece.GetColour().Value()].Or(square.GetBitboard());
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
            this.colourOccupation[piece.GetColour().Value()] = this.colourOccupation[piece.GetColour().Value()].Xor(square.GetBitboard());
        }

        public ColouredPiece GetPiece(Square square)
        {
            return this.piecesInSquare[square.GetValue()];
        }

        public bool AreAttacked(IEnumerable<Square> squares, Colour turn)
        {
            foreach(Square square in squares)
            {
                if (IsAttacked(square, turn))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Square> GetSquaresWithPiece(ColouredPiece piece)
        {
            if(piece == ColouredPiece.None)
            {
                return Enumerable.Empty<Square>();
            }

            return this.pieceOccupation[piece.GetValue()].Squares();
        }

        public int GetNumPieces(ColouredPiece piece)
        {
            if(piece == ColouredPiece.None)
            {
                return -1;
            }

            return this.pieceOccupation[piece.GetValue()].BitCount();
        }

        public bool IsAttacked(Square square, Colour turn)
        {
            Colour opponent = turn.Opponent();


            ulong diagonalAttack = SlidingBitboards.GetDiagonalAttack(square, this.occupation) |
                                   SlidingBitboards.GetAntidiagonalAttack(square, this.occupation);
            ulong linearAttack = SlidingBitboards.GetFileAttack(square, this.occupation) |
                                 SlidingBitboards.GetRankAttack(square, this.occupation);

            if (diagonalAttack != BitboardExtensions.Empty)
            {
                if ((diagonalAttack &
                (this.pieceOccupation[Piece.Queen.GetColoured(turn).GetValue()] |
                this.pieceOccupation[Piece.Bishop.GetColoured(turn).GetValue()])) != BitboardExtensions.Empty)
                {
                    return true;
                }
            }

            if (linearAttack != BitboardExtensions.Empty)
            {
                if ((linearAttack &
                (this.pieceOccupation[Piece.Queen.GetColoured(turn).GetValue()] |
                this.pieceOccupation[Piece.Rook.GetColoured(turn).GetValue()])) != BitboardExtensions.Empty)
                {
                    return true;
                }
            }

            if ((KnightBitboards.AttackBitboards[square.GetValue()] &
                this.pieceOccupation[Piece.Knight.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return true;
            }

            if ((KingBitboards.AttackBitboards[square.GetValue()] &
                this.pieceOccupation[Piece.King.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return true;
            }

            if ((PawnBitboards.AttackBitboards[opponent.Value(), square.GetValue()] &
                this.pieceOccupation[Piece.Pawn.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return true;
            }

            return false;
        }
    }
}
