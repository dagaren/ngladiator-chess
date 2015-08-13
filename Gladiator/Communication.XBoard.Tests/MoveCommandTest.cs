using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestMethod]
        public void Move_LegalMove_MoveDoneInPosition()
        {
            var move =  new Move(Square.e2, Square.e4);
            var position = Substitute.For<IPosition<IBoard>>();
            position.GetMoves(MoveSearchType.LegalMoves).Returns(new Move[] { move });
            var illegalMoveAction = Substitute.For<Action<Move, string>>();

            var command = new MoveCommand(position, move, illegalMoveAction);
            command.Execute();

            position.Received().DoMove(move);
            illegalMoveAction.DidNotReceive().Invoke(move, string.Empty);
        }

        [TestMethod]
        public void Move_IllegalMove_IllegalMoveActionExecuted()
        {
            var illegalMove = new Move(Square.g2, Square.g4);
            var move = new Move(Square.e2, Square.e4);
            var position = Substitute.For<IPosition<IBoard>>();
            position.GetMoves(MoveSearchType.LegalMoves).Returns(new Move[] { move });
            var illegalMoveAction = Substitute.For<Action<Move, string>>();

            var command = new MoveCommand(position, illegalMove, illegalMoveAction);
            command.Execute();

            position.DidNotReceive().DoMove(illegalMove);
            illegalMoveAction.Received().Invoke(illegalMove, string.Empty);
        }
    }
}
