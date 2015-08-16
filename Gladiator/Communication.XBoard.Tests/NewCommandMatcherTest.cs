using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Gladiator.Representation;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class NewCommandMatcherTest
    {
        private CommandMatcherTester<NewCommandMatcher, NewCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<NewCommandMatcher, NewCommand>(
                    new NewCommand(
                        Substitute.For<IEngine>(),
                        Substitute.For<IBuilder<IPosition<IBoard>>>()     
                    ),
                    x => new NewCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " new",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "new", 
                    CommandParameters = new Dictionary<string, string>() {}
                },
                new CommandMatching { 
                    CommandString = "new ", 
                    CommandParameters = new Dictionary<string, string>() {}
                }
            });
        }
    }
}
