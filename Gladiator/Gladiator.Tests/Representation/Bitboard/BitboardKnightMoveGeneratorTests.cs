using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Tests.Representation.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardKnightMoveGeneratorTests
    {
        [TestMethod]
        public void GetMoves_BlackKnightInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b3)
                                                .AddMove(Square.a1, Square.c2)
                                                .Build();
            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlacKnightInTheCenter_Ok()
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
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackKnightInTheCenterWithPiecesIntercepting_Ok()
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
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.d4)
                                                .PutPiece(ColouredPiece.BlackKing, Square.b5)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.b3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
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
        public void GetMoves_WhiteKnightInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b3)
                                                .AddMove(Square.a1, Square.c2)
                                                .Build();
            var moveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteKnightInTheCenter_Ok()
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
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.d4)
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

        private static void TestMoveGenerator(
            BitboardKnightMoveGenerator<Position<BitboardBoard>> moveGenerator,
            List<Move> expectedMoves,
            Position<BitboardBoard> position)
        {
            Move[] moves = moveGenerator.GetMoves(position).ToArray();

            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
