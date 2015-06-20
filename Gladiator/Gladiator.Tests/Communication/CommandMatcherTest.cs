using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Communication;
using NSubstitute;
using System.Text.RegularExpressions;

namespace Gladiator.Tests.Communication
{
    [TestClass]
    public class CommandMatcherTest
    {
        [TestMethod]
        public void Match_NotSuccess_NullReturned()
        {
            ICommandFactory commandFactory = Substitute.For<ICommandFactory>();
            Regex regex = new Regex("^command$");
            string command = "notmachingcommand";

            var commandMatcher = new CommandMatcher<ICommand>(regex, commandFactory);

            ICommand result = commandMatcher.Match(command);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Match_Success_CommandReturned()
        {
            ICommandFactory commandFactory = Substitute.For<ICommandFactory>();
            ICommand command = Substitute.For<ICommand>();
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            commandFactory.Construct<ICommand>(null).ReturnsForAnyArgs(command);
            Regex regex = new Regex("^command$");
            string commandString = "command";

            var commandMatcher = new CommandMatcher<ICommand>(regex, commandFactory);

            ICommand result = commandMatcher.Match(commandString);

            Assert.AreSame(command, result);
        }
    }
}
