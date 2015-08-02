using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Tests.Representation.Builders;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardBishopMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackBishopInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.c3)
                                                .AddMove(Square.a1, Square.d4)
                                                .AddMove(Square.a1, Square.e5)
                                                .AddMove(Square.a1, Square.f6)
                                                .AddMove(Square.a1, Square.g7)
                                                .AddMove(Square.a1, Square.h8)
                                                .Build();
            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteBishopInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.c3)
                                                .AddMove(Square.a1, Square.d4)
                                                .AddMove(Square.a1, Square.e5)
                                                .AddMove(Square.a1, Square.f6)
                                                .AddMove(Square.a1, Square.g7)
                                                .AddMove(Square.a1, Square.h8)
                                                .Build();
            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackBishopInCenter_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.b2)
                                                .AddMove(Square.d4, Square.a1)
                                                .AddMove(Square.d4, Square.c5)
                                                .AddMove(Square.d4, Square.b6)
                                                .AddMove(Square.d4, Square.a7)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.f6)
                                                .AddMove(Square.d4, Square.g7)
                                                .AddMove(Square.d4, Square.h8)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.f2)
                                                .AddMove(Square.d4, Square.g1)
                                                .Build();
            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteBishopInCenter_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.b2)
                                                .AddMove(Square.d4, Square.a1)
                                                .AddMove(Square.d4, Square.c5)
                                                .AddMove(Square.d4, Square.b6)
                                                .AddMove(Square.d4, Square.a7)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.f6)
                                                .AddMove(Square.d4, Square.g7)
                                                .AddMove(Square.d4, Square.h8)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.f2)
                                                .AddMove(Square.d4, Square.g1)
                                                .Build();
            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackBishopInTheCenterWithPiecesIntercepting_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.b2)
                                                .AddMove(Square.d4, Square.c5)
                                                .AddMove(Square.d4, Square.b6)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.f2)
                                                .Build();

            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.d4)
                                                .PutPiece(ColouredPiece.BlackKing, Square.f6)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.f2)
                                                .PutPiece(ColouredPiece.BlackRook, Square.a7)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.b2)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackKnightOpponentTurn_NoMovesExpected()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestMoveGenerator(
            BitboardBishopMoveGenerator<Position<BitboardBoard>> moveGenerator,
            List<Move> expectedMoves,
            Position<BitboardBoard> position)
        {
            Move[] moves = moveGenerator.GetMoves(position).ToArray();

            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
