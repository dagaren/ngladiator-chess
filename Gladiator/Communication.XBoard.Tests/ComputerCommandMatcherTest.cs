using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class ComputerCommandMatcherTest
    {
        private CommandMatcherTester<ComputerCommandMatcher, ComputerCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<ComputerCommandMatcher, ComputerCommand>(
                    new ComputerCommand(),
                    x => new ComputerCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " computer",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "computer", 
                    CommandParameters = new Dictionary<string, string>() {}
                },
                new CommandMatching { 
                    CommandString = "computer ", 
                    CommandParameters = new Dictionary<string, string>() {}
                }
            });
        }
    }
}
