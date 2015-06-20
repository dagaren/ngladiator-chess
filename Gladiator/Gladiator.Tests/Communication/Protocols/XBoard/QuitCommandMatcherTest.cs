using Gladiator.Communication;
using Gladiator.Communication.Protocols.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Protocols.XBoard
{
    [TestClass]
    public class QuitCommandMatcherTest
    {
        [TestMethod]
        public void Match_Ok()
        {
            ICommandFactory commandFactory = Substitute.For<ICommandFactory>();
            QuitCommand command = new QuitCommand(() => { });
            commandFactory.Construct<QuitCommand>(Arg.Any<IDictionary<string, string>>()).Returns(command);

            var commandMatcher = new QuitCommandMatcher(commandFactory);

            QuitCommand matchedCommand = commandMatcher.Match("quit");

            Assert.IsNotNull(matchedCommand);
            Assert.AreSame(command, matchedCommand);
        }

        [TestMethod]
        public void Match_WithNotMatchingCommand_NullReturned()
        {
            ICommandFactory commandFactory = Substitute.For<ICommandFactory>();
            QuitCommand command = new QuitCommand(() => { });
            commandFactory.Construct<QuitCommand>(Arg.Any<IDictionary<string, string>>()).Returns(command);

            var commandMatcher = new QuitCommandMatcher(commandFactory);

            QuitCommand matchedCommand = commandMatcher.Match("invalid");

            Assert.IsNull(matchedCommand);
        }
    }
}
