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
    public class BitboardBishopMoveGeneratorTest : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackBishopInCorner_Ok()
        {
            TestBishopInCorner(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteBishopInCorner_Ok()
        {
            TestBishopInCorner(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackBishopInCenter_Ok()
        {
            TestBishopInCenter(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteBishopInCenter_Ok()
        {
            TestBishopInCenter(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackBishopInTheCenterWithPiecesIntercepting_Ok()
        {
            TestBishopInTheCenterWithPiecesIntercepting(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteBishopInTheCenterWithPiecesIntercepting_Ok()
        {
            TestBishopInTheCenterWithPiecesIntercepting(Colour.White);
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

        private static void TestBishopInTheCenterWithPiecesIntercepting(Colour colour)
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
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Bishop.GetColoured(colour), Square.d4)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.f6)
                                                .PutPiece(Piece.Bishop.GetColoured(colour.GetOpponent()), Square.f2)
                                                .PutPiece(Piece.Rook.GetColoured(colour), Square.a7)
                                                .PutPiece(Piece.Bishop.GetColoured(colour.GetOpponent()), Square.b2)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestBishopInCenter(Colour colour)
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
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Bishop.GetColoured(colour), Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestBishopInCorner(Colour colour)
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
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Bishop.GetColoured(colour), Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
