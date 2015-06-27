using Gladiator.Communication;
using Gladiator.Communication.Protocols.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Protocols.XBoard
{
    [TestClass]
    public class XBoardCommandMatcherTest
    {
        private CommandMatcherTester<XBoardCommandMatcher, XBoardCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<XBoardCommandMatcher, XBoardCommand>(
                    new XBoardCommand(),
                    x => new XBoardCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "invalid",
                " xboard"
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "xboard", 
                    CommandParameters = new Dictionary<string, string>() {
                    }}
            });
        }
    }
}
