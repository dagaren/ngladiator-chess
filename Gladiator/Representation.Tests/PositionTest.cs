using Gladiator.Representation;
using Gladiator.Representation.Tests.Builders;
using Gladiator.Representation.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Tests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void DoMove_ValidMove_Ok()
        {
            Move validMove = new Move(Square.d1, Square.e1);
            Position<SimpleBoard> position = new PositionTestBuilder()
                .WithPieceInSquare(ColouredPiece.WhiteQueen, validMove.Source)
                .WithTurn(Colour.White)
                .WithValidMoves(validMove)
                .Build();

            bool exceptionThrown = TryDoMove(position, validMove);
            
            Assert.AreEqual(ColouredPiece.WhiteQueen, position.Board.GetPiece(validMove.Destination));
            Assert.AreEqual(ColouredPiece.None, position.Board.GetPiece(validMove.Source));
            Assert.IsFalse(exceptionThrown);
            Assert.AreEqual(Colour.Black, position.Turn);
        }

        [TestMethod]
        public void DoMove_ValidMoveWithPromotion_Ok()
        {
            Move validMove = new Move(Square.d1, Square.e1, Piece.Rook);
            Position<SimpleBoard> position = new PositionTestBuilder()
                .WithPieceInSquare(ColouredPiece.WhiteQueen, validMove.Source)
                .WithTurn(Colour.White)
                .WithValidMoves(validMove)
                .Build();

            bool exceptionThrown = TryDoMove(position, validMove);

            Assert.AreEqual(ColouredPiece.WhiteRook, position.Board.GetPiece(validMove.Destination));
            Assert.AreEqual(ColouredPiece.None, position.Board.GetPiece(validMove.Source));
            Assert.IsFalse(exceptionThrown);
            Assert.AreEqual(Colour.Black, position.Turn);
        }

        [TestMethod]
        public void DoMove_CastlingMove_Ok()
        {
            Move validMove = new Move(Square.e1, Square.g1);
            Position<SimpleBoard> position = new PositionTestBuilder()
                .WithPieceInSquare(ColouredPiece.WhiteKing, validMove.Source)
                .WithPieceInSquare(ColouredPiece.WhiteRook, Square.h1)
                .WithTurn(Colour.White)
                .WithValidMoves(validMove)
                .WithCastlingRight(CastlingType.Short, Colour.White, true)
                .Build();

            bool exceptionThrown = TryDoMove(position, validMove);

            Assert.AreEqual(ColouredPiece.WhiteKing, position.Board.GetPiece(validMove.Destination));
            Assert.AreEqual(ColouredPiece.WhiteRook, position.Board.GetPiece(Square.f1));
            Assert.AreEqual(ColouredPiece.None, position.Board.GetPiece(Square.h1));
            Assert.AreEqual(false, position.GetCastlingRight(CastlingType.Short, Colour.White));
            Assert.AreEqual(ColouredPiece.None, position.Board.GetPiece(validMove.Source));
            Assert.IsFalse(exceptionThrown);
            Assert.AreEqual(Colour.Black, position.Turn);
        }

        [TestMethod]
        public void DoMove_InvalidMove_ArgumentExceptionExpected()
        {
            Move invalidMove = new Move(Square.d1, Square.e1);
            Position<SimpleBoard> position = new PositionTestBuilder()
                .WithTurn(Colour.White)
                .WithPieceInSquare(ColouredPiece.WhiteQueen, invalidMove.Source)
                .WithValidMoves()
                .Build();

            bool exceptionThrown = TryDoMove(position, invalidMove);
            
            Assert.AreEqual(ColouredPiece.WhiteQueen, position.Board.GetPiece(invalidMove.Source));
            Assert.AreEqual(ColouredPiece.None, position.Board.GetPiece(invalidMove.Destination));
            Assert.IsTrue(exceptionThrown);
            Assert.AreEqual(Colour.White, position.Turn);
        }

        private static bool TryDoMove(Position<SimpleBoard> position, Move move)
        {
            bool exceptionThrown = false;
            try
            {
                position.DoMove(move);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            return exceptionThrown;
        }
    }
}
