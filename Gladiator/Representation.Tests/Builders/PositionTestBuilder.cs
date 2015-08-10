using Gladiator.Representation;
using Gladiator.Representation.Tests.Fakes;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Tests.Builders
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

        public PositionTestBuilder WithCastlingRight(CastlingType type, Colour colour, bool enabled)
        {
            this.position.SetCastlingRight(type, colour, enabled);

            return this;
        }

        public Position<SimpleBoard> Build()
        {
            return this.position;
        }
    }
}
