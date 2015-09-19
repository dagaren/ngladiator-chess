using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class StCommandMatcherTest
    {
        private CommandMatcherTester<StCommandMatcher, StCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<StCommandMatcher, StCommand>(
                    new StCommand(
                        Substitute.For<IEngine>(),
                        0
                    ),
                    x => new StCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "st",
                " st",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "st 10", 
                    CommandParameters = new Dictionary<string, string>() {
                       { StCommandMatcher.TimeName, "10" }
                    }
                }
            });
        }
    }
}
