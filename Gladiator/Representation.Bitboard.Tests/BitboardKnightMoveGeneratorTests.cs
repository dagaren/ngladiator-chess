using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation.Bitboard.Tests.Builders;
using Gladiator.Representation.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class BitboardKnightMoveGeneratorTests : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackKnightInCorner_Ok()
        {
            TestKnightInCorner(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKnightInCorner_Ok()
        {
            TestKnightInCorner(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlacKnightInTheCenter_Ok()
        {
            TestKnightInTheCenter(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKnightInTheCenter_Ok()
        {
            TestKnightInTheCenter(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackKnightInTheCenterWithPiecesIntercepting_Ok()
        {
            TestKnightInTheCenterWithPiecesIntercepting(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKnightInTheCenterWithPiecesIntercepting_Ok()
        {
            TestKnightInTheCenterWithPiecesIntercepting(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackKnightOpponentTurn_NoMovesExpected()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_TwoWhiteKnights_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.e2)
                                                .AddMove(Square.d4, Square.f3)
                                                .AddMove(Square.d4, Square.f5)
                                                .AddMove(Square.d4, Square.e6)
                                                .AddMove(Square.d4, Square.c6)
                                                .AddMove(Square.d4, Square.b5)
                                                .AddMove(Square.d4, Square.b3)
                                                .AddMove(Square.d4, Square.c2)
                                                .AddMove(Square.a1, Square.b3)
                                                .AddMove(Square.a1, Square.c2)
                                                .Build();

            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.d4)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKnightInTheCenterWithPiecesIntercepting(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.e2)
                                                .AddMove(Square.d4, Square.f3)
                                                .AddMove(Square.d4, Square.f5)
                                                .AddMove(Square.d4, Square.e6)
                                                .AddMove(Square.d4, Square.c6)
                                                .AddMove(Square.d4, Square.b3)
                                                .AddMove(Square.d4, Square.c2)
                                                .Build();

            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Knight.GetColoured(colour), Square.d4)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.b5)
                                                .PutPiece(Piece.Bishop.GetColoured(colour.Opponent()), Square.b3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKnightInTheCenter(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                            .AddMove(Square.d4, Square.e2)
                                                            .AddMove(Square.d4, Square.f3)
                                                            .AddMove(Square.d4, Square.f5)
                                                            .AddMove(Square.d4, Square.e6)
                                                            .AddMove(Square.d4, Square.c6)
                                                            .AddMove(Square.d4, Square.b5)
                                                            .AddMove(Square.d4, Square.b3)
                                                            .AddMove(Square.d4, Square.c2)
                                                            .Build();

            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Knight.GetColoured(colour), Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKnightInCorner(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b3)
                                                .AddMove(Square.a1, Square.c2)
                                                .Build();
            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Knight.GetColoured(colour), Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
