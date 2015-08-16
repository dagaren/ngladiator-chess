using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class GoCommandTest
    {
        [TestMethod]
        public void Execute_PositionWithWhiteTurn_ThinkingTurnChangedToWhite()
        {
            var engine = Substitute.For<IEngine>();
            var game = Substitute.For<IGame>();
            engine.CurrentGame.Returns(game);
            game.Turn.Returns(Colour.White);

            var command = new GoCommand(engine);
            command.Execute();

            engine.Received().ThinkingTurn = Colour.White;
        }
    }
}
