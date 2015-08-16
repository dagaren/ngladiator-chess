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
    public class ForceCommandMatcherTest
    {
        private CommandMatcherTester<ForceCommandMatcher, ForceCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<ForceCommandMatcher, ForceCommand>(
                    new ForceCommand(
                        Substitute.For<IEngine>()    
                    ),
                    x => new ForceCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " force",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "force", 
                    CommandParameters = new Dictionary<string, string>() {}
                },
                new CommandMatching { 
                    CommandString = "force ", 
                    CommandParameters = new Dictionary<string, string>() {}
                }
            });
        }
    }
}
