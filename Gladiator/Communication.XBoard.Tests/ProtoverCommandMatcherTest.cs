using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class ProtoverCommandMatcherTest
    {
        private CommandMatcherTester<ProtoverCommandMatcher, ProtoverCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<ProtoverCommandMatcher, ProtoverCommand>(
                    new ProtoverCommand(1, () => { }),
                    x => new ProtoverCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                " protover 1",
                "protover",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "protover 2", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "version", "2" }
                    }
                },
                new CommandMatching { 
                    CommandString = "protover 4", 
                    CommandParameters = new Dictionary<string, string>() {
                        { "version", "4" }
                    }
                },
            });
        }
    }
}
