using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class DrawCommandMatcherTest
    {
        private CommandMatcherTester<DrawCommandMatcher, DrawCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<DrawCommandMatcher, DrawCommand>(
                    new DrawCommand(),
                    x => new DrawCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " draw",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "draw", 
                    CommandParameters = new Dictionary<string, string>() {}
                },
                new CommandMatching { 
                    CommandString = "draw ", 
                    CommandParameters = new Dictionary<string, string>() {}
                }
            });
        }
    }
}
