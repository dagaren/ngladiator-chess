using Gladiator.Representation.Bitboard.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class InCheckPositionValidatorTest
    {
        [TestMethod]
        public void IsValid_WhiteKingAttackedByQueenNotInTurn_InvalidExpected()
        {
            TestKingAttackedByQueen(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByQueenNotInTurn_InvalidExpected()
        {
            TestKingAttackedByQueen(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByQueenInTurn_ValidExpected()
        {
            TestKingAttackedByQueen(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByQueenInTurn_ValidExpected()
        {
            TestKingAttackedByQueen(Colour.Black, Colour.Black, true);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByRookNotInTurn_InvalidExpected()
        {
            TestKingAttackedByRook(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByRookNotInTurn_InvalidExpected()
        {
            TestKingAttackedByRook(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByRookInTurn_ValidExpected()
        {
            TestKingAttackedByRook(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByRookInTurn_ValidExpected()
        {
            TestKingAttackedByRook(Colour.Black, Colour.Black, true);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByBishopNotInTurn_InvalidExpected()
        {
            TestKingAttackedByBishop(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByBishopNotInTurn_InvalidExpected()
        {
            TestKingAttackedByBishop(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByBishopInTurn_ValidExpected()
        {
            TestKingAttackedByBishop(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByBishopInTurn_ValidExpected()
        {
            TestKingAttackedByBishop(Colour.Black, Colour.Black, true);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByKnightNotInTurn_InvalidExpected()
        {
            TestKingAttackedByKnight(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByKnightNotInTurn_InvalidExpected()
        {
            TestKingAttackedByKnight(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByKnightInTurn_ValidExpected()
        {
            TestKingAttackedByKnight(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByKnightInTurn_ValidExpected()
        {
            TestKingAttackedByKnight(Colour.Black, Colour.Black, true);
        }
        
        [TestMethod]
        public void IsValid_WhiteKingAttackedByKingNotInTurn_InvalidExpected()
        {
            TestKingAttackedByKing(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByKingNotInTurn_InvalidExpected()
        {
            TestKingAttackedByKing(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByKingInTurn_ValidExpected()
        {
            TestKingAttackedByKing(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByKingInTurn_ValidExpected()
        {
            TestKingAttackedByKing(Colour.Black, Colour.Black, true);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByPawnNotInTurn_InvalidExpected()
        {
            TestKingAttackedByPawn(Colour.White, Colour.Black, false);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByPawnNotInTurn_InvalidExpected()
        {
            TestKingAttackedByPawn(Colour.Black, Colour.White, false);
        }

        [TestMethod]
        public void IsValid_WhiteKingAttackedByPawnInTurn_ValidExpected()
        {
            TestKingAttackedByPawn(Colour.White, Colour.White, true);
        }

        [TestMethod]
        public void IsValid_BlackKingAttackedByPawnInTurn_ValidExpected()
        {
            TestKingAttackedByPawn(Colour.Black, Colour.Black, true);
        }

        private void TestKingAttackedByQueen(Colour colour, Colour turn, bool isValidExpected)
        {
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.e8, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.e8, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.e1, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.a4, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.h4, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.h7, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.a8, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.b1, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Queen, Square.h7, isValidExpected);
        }

        private void TestKingAttackedByRook(Colour colour, Colour turn, bool isValidExpected)
        {
            TestKingAttackedByPiece(colour, turn, Piece.Rook, Square.e8, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Rook, Square.e1, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Rook, Square.a4, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Rook, Square.h4, isValidExpected);
        }

        private void TestKingAttackedByBishop(Colour colour, Colour turn, bool isValidExpected)
        {
            TestKingAttackedByPiece(colour, turn, Piece.Bishop, Square.h7, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Bishop, Square.a8, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Bishop, Square.b1, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Bishop, Square.h7, isValidExpected);
        }

        private void TestKingAttackedByKnight(Colour colour, Colour turn, bool isValidExpected)
        {
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.f6, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.d6, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.c5, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.c3, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.d2, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.f2, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.g3, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.Knight, Square.g5, isValidExpected);
        }

        private void TestKingAttackedByKing(Colour colour, Colour turn, bool isValidExpected)
        {
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.f5, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.e5, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.d5, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.d4, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.d3, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.e3, isValidExpected);
            TestKingAttackedByPiece(colour, turn, Piece.King, Square.f3, isValidExpected);
        }

        private void TestKingAttackedByPawn(Colour colour, Colour turn, bool isValidExpected)
        {
            if(colour == Colour.White)
            {
                TestKingAttackedByPiece(colour, turn, Piece.Pawn, Square.f5, isValidExpected);
                TestKingAttackedByPiece(colour, turn, Piece.Pawn, Square.d5, isValidExpected);
            }
            else if(colour == Colour.Black)
            {
                TestKingAttackedByPiece(colour, turn, Piece.Pawn, Square.f3, isValidExpected);
                TestKingAttackedByPiece(colour, turn, Piece.Pawn, Square.d3, isValidExpected);
            }
        }

        private void TestKingAttackedByPiece(Colour colour, Colour turn, Piece piece, Square attackerSquare, bool isValidExpected)
        {
            var validator = new InCheckPositionValidator<Position<BitboardBoard>>();

            Position<BitboardBoard> position = new BitboardPositionBuilder()
                                                .SetTurn(turn)
                                                .PutPiece(Piece.King.GetColoured(colour), Square.e4)
                                                .PutPiece(Piece.King.GetColoured(colour.Opponent()), Square.a1)
                                                .PutPiece(piece.GetColoured(colour.Opponent()), attackerSquare)
                                                .Build();

            bool isValid = validator.IsValid(position);

            Assert.AreEqual(isValidExpected, isValid);
        }
    }
}
