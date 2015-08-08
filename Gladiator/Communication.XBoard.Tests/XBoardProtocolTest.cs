using Gladiator.Communication;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class XBoardProtocolTest
    {
        [TestMethod]
        public void ProcessCommand_CommandMatched_CommandExecuted()
        {
            string commandString = "matchingCommand";
            IList<ICommandMatcher<ICommand>> commandMatchers = new List<ICommandMatcher<ICommand>>();
            ICommandMatcher<ICommand> commandMatcher = Substitute.For<ICommandMatcher<ICommand>>();
            ICommand command = Substitute.For<ICommand>();
            commandMatcher.Match(commandString).Returns(command);
            commandMatchers.Add(commandMatcher);

            XBoardProtocol protocol = new XBoardProtocol(commandMatchers);
            protocol.ProcessCommand(commandString);

            command.Received().Execute();
        }

        [TestMethod]
        public void ProcessCommand_CommandNotMatched_ArgumentExceptionThrown()
        {
            string commandString = "notMatchingCommand";
            IList<ICommandMatcher<ICommand>> commandMatchers = new List<ICommandMatcher<ICommand>>();
            ICommandMatcher<ICommand> commandMatcher = Substitute.For<ICommandMatcher<ICommand>>();
            commandMatchers.Add(commandMatcher);

            commandMatcher.Match(commandString).Returns(default(ICommand));

            XBoardProtocol protocol = new XBoardProtocol(commandMatchers);

            bool exceptionThrown = false;
            try
            {
                protocol.ProcessCommand(commandString);
            }
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
