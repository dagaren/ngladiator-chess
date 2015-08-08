using Gladiator.Communication;
using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
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
        private CommandMatcherTester<MoveCommandMatcher, MoveCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<MoveCommandMatcher, MoveCommand>(
                    new MoveCommand(
                        Substitute.For<IPosition<IBoard>>(),
                        new Move(),
                        Substitute.For<Action<Move, string>>()
                    ),
                    x => new MoveCommandMatcher(x));
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
