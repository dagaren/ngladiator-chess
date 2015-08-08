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
    public class BitboardQueenMoveGeneratorTest : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackQueenInCorner_Ok()
        {
            TestQueenInCorner(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteQueenInCorner_Ok()
        {
            TestQueenInCorner(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackQueenInCenter_Ok()
        {
            TestQueenInCenter(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteQueenInCenter_Ok()
        {
            TestQueenInCenter(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackQueenInCenterWithInterceptingPieces_Ok()
        {
            TestQueenInCenterWithInterceptingPieces(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteQueenInCenterWithInterceptingPieces_Ok()
        {
            TestQueenInCenterWithInterceptingPieces(Colour.White);
        }

        private static void TestQueenInCenterWithInterceptingPieces(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d6)
                                                .AddMove(Square.d4, Square.d7)
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.d2)
                                                .AddMove(Square.d4, Square.c4)
                                                .AddMove(Square.d4, Square.b4)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.f6)
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.c5)
                                                .Build();

            var moveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Queen.GetColoured(colour), Square.d4)
                                                .PutPiece(Piece.Bishop.GetColoured(colour.GetOpponent()), Square.d7)
                                                .PutPiece(Piece.Knight.GetColoured(colour.GetOpponent()), Square.d2)
                                                .PutPiece(Piece.Rook.GetColoured(colour.GetOpponent()), Square.b4)
                                                .PutPiece(Piece.Rook.GetColoured(colour), Square.f4)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.b2)
                                                .PutPiece(Piece.Pawn.GetColoured(colour), Square.e3)
                                                .PutPiece(Piece.Pawn.GetColoured(colour.GetOpponent()), Square.f6)
                                                .PutPiece(Piece.Pawn.GetColoured(colour.GetOpponent()), Square.c5)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestQueenInCorner(Colour colour)
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
                                                .AddMove(Square.a1, Square.b2)
                                                .AddMove(Square.a1, Square.c3)
                                                .AddMove(Square.a1, Square.d4)
                                                .AddMove(Square.a1, Square.e5)
                                                .AddMove(Square.a1, Square.f6)
                                                .AddMove(Square.a1, Square.g7)
                                                .AddMove(Square.a1, Square.h8)
                                                .Build();

            var moveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Queen.GetColoured(colour), Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestQueenInCenter(Colour colour)
        {
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(Square.d4, Square.d6)
                                                .AddMove(Square.d4, Square.d7)
                                                .AddMove(Square.d4, Square.d8)
                                                .AddMove(Square.d4, Square.d5)
                                                .AddMove(Square.d4, Square.d3)
                                                .AddMove(Square.d4, Square.d2)
                                                .AddMove(Square.d4, Square.d1)
                                                .AddMove(Square.d4, Square.c4)
                                                .AddMove(Square.d4, Square.b4)
                                                .AddMove(Square.d4, Square.a4)
                                                .AddMove(Square.d4, Square.e4)
                                                .AddMove(Square.d4, Square.f4)
                                                .AddMove(Square.d4, Square.g4)
                                                .AddMove(Square.d4, Square.h4)
                                                .AddMove(Square.d4, Square.e5)
                                                .AddMove(Square.d4, Square.f6)
                                                .AddMove(Square.d4, Square.g7)
                                                .AddMove(Square.d4, Square.h8)
                                                .AddMove(Square.d4, Square.c5)
                                                .AddMove(Square.d4, Square.b6)
                                                .AddMove(Square.d4, Square.a7)
                                                .AddMove(Square.d4, Square.e3)
                                                .AddMove(Square.d4, Square.f2)
                                                .AddMove(Square.d4, Square.g1)
                                                .AddMove(Square.d4, Square.c3)
                                                .AddMove(Square.d4, Square.b2)
                                                .AddMove(Square.d4, Square.a1)
                                                .Build();

            var moveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Queen.GetColoured(colour), Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
