using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Tests.Builders
{
    public class PositionBuilder<TBoard> where TBoard : IBoard
    {
        private Position<TBoard> position;

        public PositionBuilder(TBoard board, 
                               IMoveGenerator<Position<TBoard>, TBoard> moveGenerator,
                               IPositionValidator<Position<TBoard>, TBoard> positionValidator)
        {
            Check.ArgumentNotNull(board, "board");
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");
            Check.ArgumentNotNull(positionValidator, "positionValidator");

            this.position = new Position<TBoard>(board, moveGenerator, positionValidator);
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

        public Position<TBoard> Build()
        {
            return this.position;
        }
    }
}
