using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public class Position<TBoard> : IPosition<TBoard> where TBoard : IBoard
    {
        public TBoard Board { get; private set; }

        public Colour Turn { get; set; }

        private IMoveGenerator<Position<TBoard>, TBoard> moveGenerator;

        private readonly bool[,] castlingRights = new bool[2,2];

        public Position(TBoard board, IMoveGenerator<Position<TBoard>, TBoard> moveGenerator)
        {
            Check.ArgumentNotNull(board, "board");
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");

            this.Board = board;
            this.moveGenerator = moveGenerator;
            this.Turn = Colour.White;
            SetCastlingRight(CastlingType.Long, Colour.Black, false);
            SetCastlingRight(CastlingType.Long, Colour.White, false);
            SetCastlingRight(CastlingType.Short, Colour.Black, false);
            SetCastlingRight(CastlingType.Short, Colour.White, false);

        }

        public void SetCastlingRight(CastlingType type, Colour color, bool enabled)
        {
            if(color == Colour.None)
            {
                throw new ArgumentException();
            }

            this.castlingRights[type.Value(), color.Value()] = enabled;
        }

        public bool GetCastlingRight(CastlingType type, Colour color)
        {
            if (color == Colour.None)
            {
                throw new ArgumentException();
            }

            return this.castlingRights[type.Value(), color.Value()];
        }

        public void DoMove(Move move)
        {
            this.ValidateMove(move);

            ColouredPiece sourcePiece = this.Board.GetPiece(move.Source);
            ColouredPiece destinationPiece = this.Board.GetPiece(move.Destination);

            this.Board.RemovePiece(move.Source);
            if(destinationPiece != ColouredPiece.None)
            {
                this.Board.RemovePiece(move.Destination);
            }
            if(move.Promotion == Piece.None)
            {
                this.Board.PutPiece(sourcePiece, move.Destination);
            }
            else
            {
                this.Board.PutPiece(move.Promotion.GetColoured(this.Turn), move.Destination);
            }

            if(sourcePiece.GetPiece() == Piece.King)
            {
                CastlingType castlingType = move.Castling(sourcePiece);
                if(castlingType != CastlingType.None)
                {
                    this.Board.RemovePiece(CastlingTypeExtensions.RookSourceSquare(castlingType, sourcePiece.GetColour()));
                    this.Board.PutPiece(
                        Piece.Rook.GetColoured(sourcePiece.GetColour()),
                        CastlingTypeExtensions.RookDestinationSquare(castlingType, sourcePiece.GetColour()));
                }

                this.SetCastlingRight(CastlingType.Long, sourcePiece.GetColour(), false);
                this.SetCastlingRight(CastlingType.Short, sourcePiece.GetColour(), false);
            }
            else if(sourcePiece.GetPiece() == Piece.Rook)
            {
                if(move.Source == CastlingType.Short.RookSourceSquare(sourcePiece.GetColour()))
                {
                    this.SetCastlingRight(CastlingType.Short, sourcePiece.GetColour(), false);
                }
                else if(move.Source == CastlingType.Long.RookSourceSquare(sourcePiece.GetColour()))
                {
                    this.SetCastlingRight(CastlingType.Long, sourcePiece.GetColour(), false);
                }
            }

            if(destinationPiece.GetPiece() == Piece.Rook)
            {
                if(move.Destination == CastlingType.Short.RookSourceSquare(sourcePiece.GetColour().Opponent()))
                {
                    this.SetCastlingRight(CastlingType.Short, sourcePiece.GetColour().Opponent(), false);
                }
                else if (move.Destination == CastlingType.Long.RookSourceSquare(sourcePiece.GetColour().Opponent()))
                {
                    this.SetCastlingRight(CastlingType.Long, sourcePiece.GetColour().Opponent(), false);
                }
            }

            this.Turn = this.Turn.Opponent();
        }

        private void ValidateMove(Move move)
        {
            IList<Move> validMoves = this.moveGenerator.GetMoves(this);
            if (!validMoves.Contains(move))
            {
                throw new ArgumentException(string.Format("Invalid move in this position: {0}", move.Format()));
            }
        }
    }
}
