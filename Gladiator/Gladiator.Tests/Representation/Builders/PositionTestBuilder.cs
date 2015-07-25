using Gladiator.Representation;
using Gladiator.Tests.Representation.Fakes;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation.Builders
{
    class PositionTestBuilder
    {
        private SimpleBoard board;

        private IMoveGenerator<IPosition<SimpleBoard>, SimpleBoard> moveGenerator;

        private Position<SimpleBoard> position;

        public PositionTestBuilder()
        {
            this.board = new SimpleBoard();
            this.moveGenerator = Substitute.For<IMoveGenerator<IPosition<SimpleBoard>, SimpleBoard>>();
            this.position = new Position<SimpleBoard>(board, moveGenerator);
        }

        public PositionTestBuilder WithPieceInSquare(ColouredPiece piece, Square square)
        {
            this.board.PutPiece(piece, square);

            return this;
        }

        public PositionTestBuilder WithValidMoves(params Move[] moves)
        {
            this.moveGenerator.GetMoves(null).ReturnsForAnyArgs(new List<Move>(moves));

            return this;
        }

        public PositionTestBuilder WithTurn(Colour turn)
        {
            this.position.Turn = turn;

            return this;
        }

        public Position<SimpleBoard> Build()
        {
            return this.position;
        }
    }
}
