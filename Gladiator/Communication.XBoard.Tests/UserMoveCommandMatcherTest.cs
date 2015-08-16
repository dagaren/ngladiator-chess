using Gladiator.Communication;
using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class MoveCommandMatcherTest
    {
        private CommandMatcherTester<UserMoveCommandMatcher, UserMoveCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<UserMoveCommandMatcher, UserMoveCommand>(
                    new UserMoveCommand(
                        Substitute.For<IEngine>(),
                        new Move(),
                        Substitute.For<Action<Move, string>>()
                    ),
                    x => new UserMoveCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                " e2e4",
                "e2e9",
                "e2e4l",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "e2e4", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "move", "e2e4" }
                    }
                },
                new CommandMatching { 
                    CommandString = "e2e8n", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "move", "e2e8n" }
                    }
                },
            });
        }
    }
}
