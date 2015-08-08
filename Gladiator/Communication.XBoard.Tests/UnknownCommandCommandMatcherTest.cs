using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class UnknownCommandCommandMatcherTest
    {
        private CommandMatcherTester<UnknownCommandCommandMatcher, UnknownCommandCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<UnknownCommandCommandMatcher, UnknownCommandCommand>(
                    new UnknownCommandCommand(
                            Substitute.For<Action<string, string>>(),
                            string.Empty
                    ),
                    x => new UnknownCommandCommandMatcher(x));
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "e2e4", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "command", "e2e4" }
                    }
                },
                new CommandMatching { 
                    CommandString = string.Empty, 
                    CommandParameters = new Dictionary<string, string>() {
                        { "command", string.Empty }
                    }
                },
                new CommandMatching { 
                    CommandString = "xboard", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "command", "xboard" }
                    }
                },
                new CommandMatching { 
                    CommandString = "quit", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "command", "quit" }
                    }
                }
            });
        }
    }
}
