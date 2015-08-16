using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class PlayOtherCommandMatcherTest
    {
        private CommandMatcherTester<PlayOtherCommandMatcher, PlayOtherCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<PlayOtherCommandMatcher, PlayOtherCommand>(
                    new PlayOtherCommand(Substitute.For<IEngine>()),
                    x => new PlayOtherCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " playother",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "playother", 
                    CommandParameters = new Dictionary<string, string>() {}
                },
                new CommandMatching { 
                    CommandString = "playother ", 
                    CommandParameters = new Dictionary<string, string>() {}
                }
            });
        }
    }
}
