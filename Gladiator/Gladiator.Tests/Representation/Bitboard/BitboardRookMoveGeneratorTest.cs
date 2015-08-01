using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Tests.Representation.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardRookMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_BlackRookInCorner_Ok()
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
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackRook, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WithInterceptingPieces_Ok()
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
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackRook, Square.a1)
                                                .PutPiece(ColouredPiece.WhiteQueen, Square.a5)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.e1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackRookInCenterWithInterceptingPieces_Ok()
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
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackRook, Square.d4)
                                                .PutPiece(ColouredPiece.BlackBishop, Square.d7)
                                                .PutPiece(ColouredPiece.BlackKnight, Square.f4)
                                                .PutPiece(ColouredPiece.BlackPawn, Square.b4)
                                                .PutPiece(ColouredPiece.BlackKing, Square.d1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteRookInCorner_Ok()
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
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteRook, Square.a1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteRookWithInterceptingPieces_Ok()
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
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteRook, Square.a1)
                                                .PutPiece(ColouredPiece.BlackQueen, Square.a5)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.e1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhiteRookInCenterWithInterceptingPieces_Ok()
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
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhiteRook, Square.d4)
                                                .PutPiece(ColouredPiece.WhiteBishop, Square.d7)
                                                .PutPiece(ColouredPiece.WhiteKnight, Square.f4)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.b4)
                                                .PutPiece(ColouredPiece.WhiteKing, Square.d1)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
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

        private static void TestMoveGenerator(
            BitboardRookMoveGenerator<Position<BitboardBoard>> moveGenerator,
            List<Move> expectedMoves,
            Position<BitboardBoard> position)
        {
            Move[] moves = moveGenerator.GetMoves(position).ToArray();

            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
