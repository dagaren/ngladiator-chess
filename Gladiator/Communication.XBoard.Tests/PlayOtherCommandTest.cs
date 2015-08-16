using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class PlayOtherCommandTest
    {
        [TestMethod]
        public void Execute_PositionWithBlackTurn_ThinkingTurnChangedToWhite()
        {
            TestCommand(Colour.Black);
        }

        [TestMethod]
        public void Execute_PositionWithWhiteTurn_ThinkingTurnChangedToBlack()
        {
            TestCommand(Colour.White);
        }

        private void TestCommand(Colour positionTurn)
        {
            var engine = Substitute.For<IEngine>();
            var game = Substitute.For<IGame>();
            engine.CurrentGame.Returns(game);
            game.Turn.Returns(positionTurn);

            var command = new PlayOtherCommand(engine);
            command.Execute();

            engine.Received().ThinkingTurn = positionTurn.Opponent();
        }
    }
}
