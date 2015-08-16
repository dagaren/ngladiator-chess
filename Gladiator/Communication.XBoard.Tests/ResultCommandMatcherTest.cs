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
    public class ResultCommandMatcherTest
    {
        private CommandMatcherTester<ResultCommandMatcher, ResultCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<ResultCommandMatcher, ResultCommand>(
                    new ResultCommand(
                        Substitute.For<IEngine>(),
                        "result",
                        "comment"
                    ),
                    x => new ResultCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " result",
                "result",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "result * ", 
                    CommandParameters = new Dictionary<string, string>() {
                       { "result", "*" },
                       { "comment", string.Empty }
                    }
                },
                new CommandMatching { 
                    CommandString = "result 1-0 { mate } ", 
                    CommandParameters = new Dictionary<string, string>() {
                       { "result", "1-0" },
                       { "comment", "{ mate }" }
                    }
                }
            });
        }
    }
}
