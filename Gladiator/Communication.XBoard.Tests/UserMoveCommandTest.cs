using Gladiator.Core;
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
        public void Execute_LegalMove_MoveDoneInPosition()
        {
            var move =  new Move(Square.e2, Square.e4);
            var engine = Substitute.For<IEngine>();
            var illegalMoveAction = Substitute.For<Action<Move, string>>();

            var command = new UserMoveCommand(engine, move, illegalMoveAction);
            command.Execute();

            engine.Received().DoMove(move);
            illegalMoveAction.DidNotReceive().Invoke(move, string.Empty);
        }

        [TestMethod]
        public void Execute_IllegalMove_IllegalMoveActionExecuted()
        {
            var move = new Move(Square.e2, Square.e4);
            var engine = Substitute.For<IEngine>();
            engine.When(g => g.DoMove(move)).Do(g => { throw new IllegalMoveException(); });
            var illegalMoveAction = Substitute.For<Action<Move, string>>();

            var command = new UserMoveCommand(engine, move, illegalMoveAction);
            command.Execute();

            engine.Received().DoMove(move);
            illegalMoveAction.Received().Invoke(move, string.Empty);
        }
    }
}
