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
    public class BitboardKingMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackKingInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.a2)
                                                .AddMove(Square.a1, Square.b1)
                                                .Build();
            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKing, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackKingInTheCenter_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.c4)
                                                .AddMove(Square.d4, Square.c5)
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKing, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackKingInTheCenterWithPiecesIntercepting_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.c5)
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackKing, Square.d4)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.c4)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.c3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackKingOpponentTurn_NoMovesExpected()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.BlackKing, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteKingInCorner_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.a2)
                                                .AddMove(Square.a1, Square.b1)
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteKing, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteKingInTheCenterWithPiecesIntercepting_Ok()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.c5)
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteKing, Square.d4)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.c4)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.c3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestMoveGenerator(
            BitboardKingMoveGenerator<Position<BitboardBoard>> moveGenerator,
            List<Move> expectedMoves,
            Position<BitboardBoard> position)
        {
            Move[] moves = moveGenerator.GetMoves(position).ToArray();

            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
