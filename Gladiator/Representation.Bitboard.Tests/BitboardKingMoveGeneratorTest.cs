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

        [TestMethod]
        public void GetMoves_WhiteWithCastlingRights_CastlingMovesGenerated()
        {
            TestKingCastling(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackWithCastlingRights_CastlingMovesGenerated()
        {
            TestKingCastling(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteWithCastlingRightsInterceptingPieces_NoCastlingMovesGenerated()
        {
            TestKingCastlingWithInterceptingPieces(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackWithCastlingRightsInterceptingPieces_NoCastlingMovesGenerated()
        {
            TestKingCastlingWithInterceptingPieces(Colour.Black);
        }

        [TestMethod]
        public void GetMoves_WhiteWithoutCastlingRights_NoCastlingMovesGenerated()
        {
            TestKingCastlingWithoutCastlingRights(Colour.White);
        }

        [TestMethod]
        public void GetMoves_BlackWithoutCastlingRights_NoCastlingMovesGenerated()
        {
            TestKingCastlingWithoutCastlingRights(Colour.Black);
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
                                                .PutPiece(Piece.Bishop.GetColoured(colour.Opponent()), Square.c3)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKingCastling(Colour colour)
        {
            Square kingSquare = CastlingTypeExtensions.KingSourceSquare(CastlingType.Short, colour);

            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMove(MoveExtensions.GenerateCastling(CastlingType.Long, colour))
                                                .AddMove(MoveExtensions.GenerateCastling(CastlingType.Short, colour))
                                                .AddMoves(kingSquare, KingBitboards.AttackBitboards[kingSquare.GetValue()].Squares())
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour), 
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Long, colour))
                                                .PutPiece(Piece.Rook.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Short, colour))
                                                .PutPiece(Piece.King.GetColoured(colour), 
                                                          kingSquare)
                                                .SetCastlingRight(CastlingType.Short, colour, true)
                                                .SetCastlingRight(CastlingType.Long, colour, true)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKingCastlingWithoutCastlingRights(Colour colour)
        {
            Square kingSquare = CastlingTypeExtensions.KingSourceSquare(CastlingType.Short, colour);

            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMoves(kingSquare, KingBitboards.AttackBitboards[kingSquare.GetValue()].Squares())
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Long, colour))
                                                .PutPiece(Piece.Rook.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Short, colour))
                                                .PutPiece(Piece.King.GetColoured(colour),
                                                          kingSquare)
                                                .SetCastlingRight(CastlingType.Short, colour, false)
                                                .SetCastlingRight(CastlingType.Long, colour, false)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }

        private static void TestKingCastlingWithInterceptingPieces(Colour colour)
        {
            Square kingSquare = CastlingTypeExtensions.KingSourceSquare(CastlingType.Short, colour);

            List<Move> expectedMoves = new MoveListBuilder()
                                                .AddMoves(kingSquare, KingBitboards.AttackBitboards[kingSquare.GetValue()].Squares())
                                                .Build();

            var moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            Position<BitboardBoard> position = new BitboardPositionBuilder(moveGenerator)
                                                .SetTurn(colour)
                                                .PutPiece(Piece.Rook.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Long, colour))
                                                .PutPiece(Piece.Rook.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Short, colour))
                                                .PutPiece(Piece.King.GetColoured(colour),
                                                          kingSquare)
                                                .PutPiece(Piece.Knight.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Long, colour).NextInRank())
                                                .PutPiece(Piece.Knight.GetColoured(colour),
                                                          CastlingTypeExtensions.RookSourceSquare(CastlingType.Short, colour).PreviousInRank())
                                                .SetCastlingRight(CastlingType.Short, colour, true)
                                                .SetCastlingRight(CastlingType.Long, colour, true)
                                                .Build();

            TestMoveGenerator(moveGenerator, expectedMoves, position);
        }
    }
}
