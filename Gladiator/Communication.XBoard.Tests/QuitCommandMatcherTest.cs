using Gladiator.Communication;
using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class QuitCommandMatcherTest
    {
        private CommandMatcherTester<QuitCommandMatcher, QuitCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<QuitCommandMatcher, QuitCommand>(
                    new QuitCommand(() => { }),
                    x => new QuitCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " quit"
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "quit", 
                    CommandParameters = new Dictionary<string, string>() {
                    }}
            });
        }
    }
}
