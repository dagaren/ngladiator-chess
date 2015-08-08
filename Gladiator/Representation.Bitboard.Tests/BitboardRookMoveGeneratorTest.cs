using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Representation.Bitboard.Tests.Builders;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class BitboardRookMoveGeneratorTest : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackRookInCorner_Ok()
        {
            TestRookInCorner(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteRookInCorner_Ok()
        {
            TestRookInCorner(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackRookWithInterceptingPieces_Ok()
        {
            TestRookInCornerWithInterceptingPieces(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteRookWithInterceptingPieces_Ok()
        {
            TestRookInCornerWithInterceptingPieces(Colour.White);
        }

        [TestMethod]
        public void GetMoves_WhiteRookInCenterWithInterceptingPieces_Ok()
        {
            TestRookInCenterWithInterceptingPieces(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackRookInCenterWithInterceptingPieces_Ok()
        {
            TestRookInCenterWithInterceptingPieces(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_BoardWithouthRooks_NoMovesExpected()
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.WhiteQueen, Square.a5)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.e1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestRookInCenterWithInterceptingPieces(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.d6)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.c4)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.d2)
                                                .Build();

            var moveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour), Square.d4)
                                                .PutPiece(Piece.Bishop.GetColoured(colour), Square.d7)
                                                .PutPiece(Piece.Knight.GetColoured(colour), Square.f4)
                                                .PutPiece(Piece.Pawn.GetColoured(colour), Square.b4)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.d1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestRookInCornerWithInterceptingPieces(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.a2)
                                                .AddMove(Square.a1, Square.a3)
                                                .AddMove(Square.a1, Square.a4)
                                                .AddMove(Square.a1, Square.a5)
                                                .AddMove(Square.a1, Square.b1)
                                                .AddMove(Square.a1, Square.c1)
                                                .AddMove(Square.a1, Square.d1)
                                                .Build();

            var moveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour), Square.a1)
                                                .PutPiece(Piece.Queen.GetColoured(colour.GetOpponent()), Square.a5)
                                                .PutPiece(Piece.Bishop.GetColoured(colour), Square.e1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestRookInCorner(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.a1, Square.a2)
                                                .AddMove(Square.a1, Square.a3)
                                                .AddMove(Square.a1, Square.a4)
                                                .AddMove(Square.a1, Square.a5)
                                                .AddMove(Square.a1, Square.a6)
                                                .AddMove(Square.a1, Square.a7)
                                                .AddMove(Square.a1, Square.a8)
                                                .AddMove(Square.a1, Square.b1)
                                                .AddMove(Square.a1, Square.c1)
                                                .AddMove(Square.a1, Square.d1)
                                                .AddMove(Square.a1, Square.e1)
                                                .AddMove(Square.a1, Square.f1)
                                                .AddMove(Square.a1, Square.g1)
                                                .AddMove(Square.a1, Square.h1)
                                                .Build();

            var moveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour), Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
