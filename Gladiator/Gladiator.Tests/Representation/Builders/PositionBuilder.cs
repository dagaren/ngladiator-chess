using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Tests.Representation.Builders
{
    class PositionBuilder<TBoard> where TBoard : IBoard
    {
        private Position<TBoard> position;

        public PositionBuilder(TBoard board, IMoveGenerator<Position<TBoard>, TBoard> moveGenerator)
        {
            Check.ArgumentNotNull(board, "board");
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");

            this.position = new Position<TBoard>(board, moveGenerator);
        }

        public PositionBuilder<TBoard> SetTurn(Colour turn)
        {
            this.position.Turn = turn;

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
