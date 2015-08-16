using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class NewCommandTest
    {
        [TestMethod]
        public void Execute_NewGameStartedAndThinkingTurnSetToBlack()
        {
            var engine = Substitute.For<IEngine>();
            var positionBuilder = Substitute.For<IBuilder<IPosition<IBoard>>>();
            var position = Substitute.For<IPosition<IBoard>>();
            positionBuilder.Build().Returns(position);

            NewCommand command = new NewCommand(engine, positionBuilder);
            command.Execute();

            engine.Received().NewGame(position);
            engine.Received().ThinkingTurn = Colour.Black;
        }
    }
}
