using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class ForceCommandTest
    {
        [TestMethod]
        public void Execute_ThinkingTurnChangedToNone()
        {
            var engine = Substitute.For<IEngine>();

            var command = new ForceCommand(engine);
            command.Execute();

            engine.Received().ThinkingTurn = Colour.None;
        }
    }
}
