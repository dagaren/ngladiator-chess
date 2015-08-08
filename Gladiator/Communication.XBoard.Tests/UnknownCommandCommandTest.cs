using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class UnknownCommandCommandTest
    {
        [TestMethod]
        public void Execute_Ok()
        {
            const string commandText = "command";
            var action = Substitute.For<Action<string, string>>();
            UnknownCommandCommand command = new UnknownCommandCommand(action, commandText);
            command.Execute();

            action.Received().Invoke("Unknown command", "command");
        }
    }
}
