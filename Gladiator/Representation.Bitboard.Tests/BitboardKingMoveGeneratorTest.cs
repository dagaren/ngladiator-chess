using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Representation.Tests.Builders;
using Gladiator.Representation.Bitboard.Tests.Builders;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class BitboardKingMoveGeneratorTest : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackKingInCorner_Ok()
        {
            TestKingInCorner(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKingInCorner_Ok()
        {
            TestKingInCorner(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackKingInTheCenter_Ok()
        {
            TestKingInTheCenter(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKingInTheCenter_Ok()
        {
            TestKingInTheCenter(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackKingInTheCenterWithPiecesIntercepting_Ok()
        {
            TestKingInCenterWithInterceptingPieces(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteKingInTheCenterWithPiecesIntercepting_Ok()
        {
            TestKingInCenterWithInterceptingPieces(Colour.White);
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

        private static void TestKingInCorner(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.a2)
                                                .AddMove(Square.a1, Square.b1)
                                                .Build();
            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKingInTheCenter(Colour colour)
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
                                                .SetTurn(colour)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKingInCenterWithInterceptingPieces(Colour colour)
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
                                                .SetTurn(colour)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.d4)
                                                .PutPiece(Piece.Knight.GetColoured(colour), Square.c4)
                                                .PutPiece(Piece.Bishop.GetColoured(colour.GetOpponent()), Square.c3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
