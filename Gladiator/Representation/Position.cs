using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Representation
{
    public class Position<TBoard> : IPosition<TBoard> where TBoard : IBoard
    {
        public TBoard Board { get; private set; }

        public Colour Turn { get; set; }

        public Square EnPassantSquare { get; set; }

        private readonly bool[,] castlingRights = new bool[2, 2];

        private IMoveGenerator<Position<TBoard>, TBoard> moveGenerator;

        private IPositionValidator<Position<TBoard>, TBoard> positionValidator;

        public Position(TBoard board, 
                        IMoveGenerator<Position<TBoard>, TBoard> moveGenerator,
                        IPositionValidator<Position<TBoard>, TBoard> positionValidator)
        {
            Check.ArgumentNotNull(board, "board");
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");
            Check.ArgumentNotNull(positionValidator, "positionValidator");

            this.Board = board;
            this.Turn = Colour.White;
            this.EnPassantSquare = Square.None;
            this.moveGenerator = moveGenerator;
            this.positionValidator = positionValidator;
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

        public FullMove DoMove(Move move)
        {
            this.ValidateMove(move);

            FullMove fullMove = new FullMove(move);

            fullMove.SourcePiece = this.Board.GetPiece(move.Source);
            fullMove.DestinationPiece = this.Board.GetPiece(move.Destination);

            this.Board.RemovePiece(move.Source);
            if(fullMove.DestinationPiece != ColouredPiece.None)
            {
                this.Board.RemovePiece(move.Destination);
            }
            if(move.Promotion == Piece.None)
            {
                this.Board.PutPiece(fullMove.SourcePiece, move.Destination);
            }
            else
            {
                this.Board.PutPiece(move.Promotion.GetColoured(this.Turn), move.Destination);
            }

            HandleCastling(fullMove);

            HandleEnPassant(fullMove);
            
            this.Turn = this.Turn.Opponent();

            return fullMove;
        }

        public void UndoMove(FullMove move)
        {
            Colour colour = move.SourcePiece.GetColour();
            this.Board.RemovePiece(move.Destination);
            if (move.DestinationPiece != ColouredPiece.None)
            {
                this.Board.PutPiece(move.DestinationPiece, move.Destination);
            }
            this.Board.PutPiece(move.SourcePiece, move.Source);

            if(move.IsInPassantCapture)
            {
                this.Board.PutPiece(Piece.Pawn.GetColoured(colour), PawnExtensions.EnPassantCapturedPawnSquare[move.Destination.GetValue()]);
            }

            CastlingType castlingType = move.Castling(move.SourcePiece);
            if(castlingType != CastlingType.None)
            {
                this.Board.PutPiece(Piece.Rook.GetColoured(colour), CastlingTypeExtensions.RookSourceSquare(castlingType, colour));
            }

            this.EnPassantSquare = move.PreviousEnPassantSquare;

            if(move.CancelsLongCastling)
            {
                this.SetCastlingRight(CastlingType.Long, colour, true);
            }
            if(move.CancelsShortCastling)
            {
                this.SetCastlingRight(CastlingType.Short, colour, true);
            }

            this.Turn = colour;
        }

        public IEnumerable<Move> GetMoves(MoveSearchType searchType)
        {
            IEnumerable<Move> pseudoLegalMoves = this.moveGenerator.GetMoves(this);

            if(searchType == MoveSearchType.LegalMoves)
            {
                return pseudoLegalMoves.Where(move =>
                {
                    FullMove fullMove = this.DoMove(move);
                    bool isValid = this.positionValidator.IsValid(this);
                    this.UndoMove(fullMove);

                    return isValid;
                });
            }

            return pseudoLegalMoves;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Position<TBoard> position = obj as Position<TBoard>;
            if ((object)position == null)
            {
                return false;
            }

            return (position.Turn == this.Turn) &&
                   (position.EnPassantSquare == this.EnPassantSquare) &&
                   (position.GetCastlingRight(CastlingType.Long, Colour.White) == this.GetCastlingRight(CastlingType.Long, Colour.White)) &&
                   (position.GetCastlingRight(CastlingType.Short, Colour.White) == this.GetCastlingRight(CastlingType.Short, Colour.White)) &&
                   (position.GetCastlingRight(CastlingType.Long, Colour.Black) == this.GetCastlingRight(CastlingType.Long, Colour.Black)) &&
                   (position.GetCastlingRight(CastlingType.Short, Colour.Black) == this.GetCastlingRight(CastlingType.Short, Colour.Black)) &&
                   (position.Board.AreEqual(this.Board));
        }

        private void HandleEnPassant(FullMove move)
        {
            if (move.SourcePiece.GetPiece() == Piece.Pawn && move.Destination == EnPassantSquare)
            {
                this.Board.RemovePiece(PawnExtensions.EnPassantCapturedPawnSquare[move.Destination.GetValue()]);

                move.IsInPassantCapture = true;
            }

            move.PreviousEnPassantSquare = this.EnPassantSquare;

            this.EnPassantSquare = move.EnPassantSquareGenerated(move.SourcePiece);
        }

        private void HandleCastling(FullMove move)
        {
            if (move.SourcePiece.GetPiece() == Piece.King)
            {
                CastlingType castlingType = move.Castling(move.SourcePiece);
                if (castlingType != CastlingType.None)
                {
                    this.Board.RemovePiece(CastlingTypeExtensions.RookSourceSquare(castlingType, move.SourcePiece.GetColour()));
                    this.Board.PutPiece(
                        Piece.Rook.GetColoured(move.SourcePiece.GetColour()),
                        CastlingTypeExtensions.RookDestinationSquare(castlingType, move.SourcePiece.GetColour()));
                }

                this.SetCastlingRight(CastlingType.Long, move.SourcePiece.GetColour(), false);
                this.SetCastlingRight(CastlingType.Short, move.SourcePiece.GetColour(), false);

                move.CancelsShortCastling = true;
                move.CancelsLongCastling = true;
            }
            else if (move.SourcePiece.GetPiece() == Piece.Rook)
            {
                if (move.Source == CastlingType.Short.RookSourceSquare(move.SourcePiece.GetColour()))
                {
                    this.SetCastlingRight(CastlingType.Short, move.SourcePiece.GetColour(), false);
                    move.CancelsShortCastling = true;
                }
                else if (move.Source == CastlingType.Long.RookSourceSquare(move.SourcePiece.GetColour()))
                {
                    this.SetCastlingRight(CastlingType.Long, move.SourcePiece.GetColour(), false);
                    move.CancelsLongCastling = true;
                }
            }

            if (move.DestinationPiece.GetPiece() == Piece.Rook)
            {
                if (move.Destination == CastlingType.Short.RookSourceSquare(move.SourcePiece.GetColour().Opponent()))
                {
                    this.SetCastlingRight(CastlingType.Short, move.SourcePiece.GetColour().Opponent(), false);
                    move.CancelsShortCastling = true;
                }
                else if (move.Destination == CastlingType.Long.RookSourceSquare(move.SourcePiece.GetColour().Opponent()))
                {
                    this.SetCastlingRight(CastlingType.Long, move.SourcePiece.GetColour().Opponent(), false);
                    move.CancelsLongCastling = true;
                }
            }
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
