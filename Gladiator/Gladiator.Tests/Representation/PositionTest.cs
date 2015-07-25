using Gladiator.Representation;
using Gladiator.Tests.Representation.Builders;
using Gladiator.Tests.Representation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation
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
