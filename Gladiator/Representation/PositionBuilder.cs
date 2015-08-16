using Gladiator.Utils;
using System;

namespace Gladiator.Representation
{
    public class PositionBuilder<TBoard> : IBuilder<Position<TBoard>> 
        where TBoard : IBoard, new()
    {
        protected Position<TBoard> position;

        public PositionBuilder(IMoveGenerator<Position<TBoard>, TBoard> moveGenerator,
                               IPositionValidator<Position<TBoard>, TBoard> positionValidator)
        {
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");
            Check.ArgumentNotNull(positionValidator, "positionValidator");

            TBoard board = new TBoard();
            this.position = new Position<TBoard>(board, moveGenerator, positionValidator);
        }

        public Position<TBoard> Build()
        {
            return this.position.GetCopy();
        }

        public PositionBuilder<TBoard> SetTurn(Colour turn)
        {
            this.position.Turn = turn;

            return this;
        }

        public PositionBuilder<TBoard> SetEnPassantSquare(Square square)
        {
            this.position.EnPassantSquare = square;

            return this;
        }

        public PositionBuilder<TBoard> SetCastlingRight(CastlingType type, Colour colour, bool enabled)
        {
            this.position.SetCastlingRight(type, colour, enabled);

            return this;
        }

        public PositionBuilder<TBoard> PutPiece(ColouredPiece colouredPiece, Square square)
        {
            this.position.Board.PutPiece(colouredPiece, square);

            return this;
        }

        public PositionBuilder<TBoard> PutPiece(ColouredPiece colouredPiece, params Square[] squares)
        {
            foreach(Square square in squares)
            {
                this.position.Board.PutPiece(colouredPiece, square);
            }

            return this;
        }
    }
}
