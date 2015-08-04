using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Tests.Representation.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardPawnMoveGeneratorTest : BitboardMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_WhitePawnInThirdRank_Ok()
        {
            Square square = Square.d3;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d4)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInSecondRank_Ok()
        {
            Square square = Square.d2;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d3)
                                                .AddMove(square, Square.d4)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInSecondRankWithInterceptingPieceInThirdRank_Ok()
        {
            Square square = Square.d2;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .PutPiece(ColouredPiece.BlackPawn,  Square.d3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInSecondRankWithInterceptingPieceInForthRank_Ok()
        {
            Square square = Square.d2;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d3)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .PutPiece(ColouredPiece.BlackPawn, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInThirdRankWithInterceptingPiece_Ok()
        {
            Square square = Square.d3;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .PutPiece(ColouredPiece.BlackPawn, Square.d4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInThirdRankCapturesPossible_Ok()
        {
            Square square = Square.d3;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d4)
                                                .AddMove(square, Square.e4)
                                                .AddMove(square, Square.c4)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .PutPiece(ColouredPiece.BlackPawn, Square.e4)
                                                .PutPiece(ColouredPiece.BlackPawn, Square.c4)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        /////////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void GetMoves_BlackPawnInSixthRank_Ok()
        {
            Square square = Square.d6;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d5)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSeventhRank_Ok()
        {
            Square square = Square.d7;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d6)
                                                .AddMove(square, Square.d5)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSeventhRankWithInterceptingPieceInSixthRank_Ok()
        {
            Square square = Square.d7;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.d6)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSeventhRankWithInterceptingPieceInFifthRank_Ok()
        {
            Square square = Square.d7;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d6)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.d5)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSixthRankWithInterceptingPiece_Ok()
        {
            Square square = Square.d6;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.d5)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSixthRankCapturesPossible_Ok()
        {
            Square square = Square.d6;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d5)
                                                .AddMove(square, Square.e5)
                                                .AddMove(square, Square.c5)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.e5)
                                                .PutPiece(ColouredPiece.WhitePawn, Square.c5)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_WhitePawnInSeventhRank_PromotionMovesReturned()
        {
            Square square = Square.d7;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d8, Piece.Knight)
                                                .AddMove(square, Square.d8, Piece.Bishop)
                                                .AddMove(square, Square.d8, Piece.Rook)
                                                .AddMove(square, Square.d8, Piece.Queen)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.White)
                                                .PutPiece(ColouredPiece.WhitePawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        [TestMethod]
        public void GetMoves_BlackPawnInSecondRank_PromotionMovesReturned()
        {
            Square square = Square.d2;
            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(square, Square.d1, Piece.Knight)
                                                .AddMove(square, Square.d1, Piece.Bishop)
                                                .AddMove(square, Square.d1, Piece.Rook)
                                                .AddMove(square, Square.d1, Piece.Queen)
                                                .Build();

            var moveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(Colour.Black)
                                                .PutPiece(ColouredPiece.BlackPawn, square)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
